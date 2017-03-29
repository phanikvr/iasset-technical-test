using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IAssetTechnical.Models;
using IAssetTechnical.Repositories;
using System.Web;

namespace IAssetTechnical.Controllers
{
    [RoutePrefix("api/Weather")]
    public class WeatherController : ApiController
    {
        private readonly IDynamicRepository _repository;

        public WeatherController(IDynamicRepository repository)
        {
            _repository = repository;
        }

        [Route("GetCities")]
        [HttpGet]
        public IHttpActionResult Get(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
            {
                return BadRequest("Country Name is missing");
            }
            else
            {
                return Ok(_repository.GetRepository(ControllerContext.Request.Headers.Contains("USE-MOCK")).GetCitiesByCountry(countryName));
            }
        }

        [Route("GetWeather")]
        [HttpPost]
        public IHttpActionResult POST([FromBody] WeatherViewModel weatherModel)
        {
            // when no input, the Values collection will be empty so ModelState.IsValid will be true.
            // need to explicitly handle this case
            if (ModelState.IsValid && weatherModel != null)
                return Ok(_repository.GetRepository(ControllerContext.Request.Headers.Contains("USE-MOCK")).GetWeather(weatherModel.Country, weatherModel.City));
            else
                return BadRequest(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
        }       
    }
}

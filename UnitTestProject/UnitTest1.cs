using System;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IAssetTechnical.Controllers;
using IAssetTechnical.Repositories;
using System.Net.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.Web.Routing;
using System.Web.Http.Hosting;
using System.Linq;
using IAssetTechnical.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetCitiesForCountryAustralia()
        {
            IDynamicRepository repository = new DynamicRepository();
            var controller = new WeatherController(repository);
            var moqContext = new Mock<HttpContextBase>();
            controller.Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };
            
            // as the web service faling need to mock.
            controller.Request.Headers.Add("USE-MOCK", "True");
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get("Australia");
            var httpReponse = response as System.Web.Http.Results.OkNegotiatedContentResult<IEnumerable<string>>;
            Assert.AreEqual(3, httpReponse.Content.Count());
        }

        [TestMethod]
        public void TestGetWeatherDeatails()
        {
            IDynamicRepository repository = new DynamicRepository();
            var controller = new WeatherController(repository);
            var moqContext = new Mock<HttpContextBase>();
            controller.Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };

            // as the web service faling need to mock.
            controller.Request.Headers.Add("USE-MOCK", "True");
            controller.Configuration = new HttpConfiguration();

            var response = controller.POST(new WeatherViewModel { Country = "Australia", City= "Sydney" });
            var httpReponse = response as System.Web.Http.Results.OkNegotiatedContentResult<WeatherReportViewModel>;
            Assert.IsNotNull(httpReponse.Content);
        }

        [TestMethod]
        public void TestGetCitiesInputValidation()
        {
            IDynamicRepository repository = new DynamicRepository();
            var controller = new WeatherController(repository);
            var moqContext = new Mock<HttpContextBase>();
            controller.Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            };

            // as the web service faling need to mock.
            controller.Request.Headers.Add("USE-MOCK", "True");
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(null);
            var httpReponse = response as System.Web.Http.Results.BadRequestErrorMessageResult;
            Assert.AreEqual("Country Name is missing", httpReponse.Message);
        }

        [TestMethod]
        public void TestGetWeatherInputValidationNullInput()
        {
            IDynamicRepository repository = new DynamicRepository();
            var controller = new WeatherController(repository);
            var moqContext = new Mock<HttpContextBase>();
            controller.Request = new HttpRequestMessage()
            {
                Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } },
                Method = new HttpMethod("post")
            };

            controller.ModelState.AddModelError("country", "Country Name is missing");
            controller.ModelState.AddModelError("country", "City Name is missing");

            // as the web service faling need to mock.
            controller.Request.Headers.Add("USE-MOCK", "True");
            controller.Configuration = new HttpConfiguration();

            var response = controller.POST(null);
            var httpReponse = response as System.Web.Http.Results.BadRequestErrorMessageResult;
            Assert.AreEqual("Country Name is missing; City Name is missing", httpReponse.Message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using IAssetTechnical.GlobalWeatherProxy;
using IAssetTechnical.Models;

namespace IAssetTechnical.Repositories
{    
    public class WeatherRepository : IWeatherRepository
    {
        private readonly GlobalWeatherSoapClient _soapClient;

        public WeatherRepository()
        {
            _soapClient = new GlobalWeatherSoapClient("GlobalWeatherSoap12");
        }
        public WeatherReportViewModel GetWeather(string cityName, string countryName)
        {
            var result = _soapClient.GetWeather(cityName, countryName);
           return new WeatherReportViewModel() {};
        }

        public IEnumerable<string> GetCitiesByCountry(string countryName)
        {
            var result = _soapClient.GetCitiesByCountry(countryName);
            var doc = XDocument.Parse(result);
            //var idNodes = doc.SelectNodes("NewDataSet/Table/City");
            var cityList = doc.Root
                                  .Elements("Table")
                                  .Elements("City")
                                  .Select(x => (string)x)
                                  .ToList();
            return cityList;
        }
    }
}
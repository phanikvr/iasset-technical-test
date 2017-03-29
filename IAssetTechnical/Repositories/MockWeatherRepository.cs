using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using IAssetTechnical.GlobalWeatherProxy;
using IAssetTechnical.Models;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IAssetTechnical.Repositories
{    
    public class MockWeatherRepository : IWeatherRepository
    {        
        public WeatherReportViewModel GetWeather(string cityName, string countryName)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(ConfigurationManager.AppSettings["AlternateWebService"], cityName));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(uri).Result;

            // parsing to JsonObject to traverse
            var jObject = Newtonsoft.Json.Linq.JObject.Parse(response.Content.ReadAsStringAsync().Result);
            
            return new WeatherReportViewModel
            { 
                DewPoint = "",
                Location = string.Format("Long:{0}, Latt:{1}",jObject["coord"]["lon"].ToString(), jObject["coord"]["lat"].ToString()),
                Pressure = "1024.06",
                RelativeHumidity = jObject["main"]["humidity"].ToString(),
                SkyConditions = jObject["weather"][0]["description"].ToString(),
                Temperature = jObject["main"]["temp"].ToString(),
                Time= DateTime.Now.ToShortTimeString(),
                Visibility = jObject["visibility"].ToString(),
                Wind = jObject["wind"]["speed"].ToString()                               
           };
        }

        public IEnumerable<string> GetCitiesByCountry(string countryName)
        {
            return new List<string>() { "Sydney", "Melbourne", "Brisbane" };
        }
    }
}
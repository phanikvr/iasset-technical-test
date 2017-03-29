using IAssetTechnical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAssetTechnical.Repositories
{
    public interface IWeatherRepository
    {
        WeatherReportViewModel GetWeather(string cityName, string countryName);
        IEnumerable<string> GetCitiesByCountry(string countryName);
    }
}

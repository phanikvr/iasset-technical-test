using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAssetTechnical.Repositories
{
    public class DynamicRepository : IDynamicRepository
    {
        public IWeatherRepository GetRepository(bool useMock)
        {
            if (useMock)
                return new MockWeatherRepository();
            else
                return new WeatherRepository();
        }
    }
}
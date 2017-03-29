using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IAssetTechnical.Models
{
    public class WeatherReportViewModel
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }

        [DisplayName("Sky Conditions")]
        public string SkyConditions { get; set; }
        public string Temperature { get; set; }

        [DisplayName("Dew Point")]
        public string DewPoint { get; set; }

        [DisplayName("Relative Humidity")]
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}
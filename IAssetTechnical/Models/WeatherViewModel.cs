using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAssetTechnical.Models
{
    public class WeatherViewModel
    {
        [Required(ErrorMessage="Country Name is missing")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City Name is missing")]
        public string City { get; set; }
    }
}
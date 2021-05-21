using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherFCProject.Models
{
    public class Weather
    {
        [Key]
        public int ID { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public float HighTemp { get; set; }
        public float LowTemp { get; set; }
        public string ForeCast { get; set; }

    }
}

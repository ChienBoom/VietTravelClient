using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelClient.Models.WeatherModel
{
    public class Main
    {
        public float  Temp { get; set; }
        public float Feels_like { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float Sea_level { get; set; }
        public float Grnd_level { get; set; }
    }
}

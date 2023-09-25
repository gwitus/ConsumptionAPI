using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherForecast.Entities
{
    public class Weather {
        public string city { get; set; }
        // umidade
        public string damp {get; set;}
        public string temperatureInCelsius {get; set;}
    }
}
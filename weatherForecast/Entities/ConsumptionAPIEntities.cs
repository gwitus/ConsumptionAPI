using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace weatherForecast.Entities
{
    public class Weather {
        [JsonProperty("location")]
        public Location Location { get; set; }
        // umidade
        public string humidity {get; set;}
    }

      public class Location
    {
        public string Name { get; set; }
    }
}
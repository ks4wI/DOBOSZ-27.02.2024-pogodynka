using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12
{
    public class WeatherData
    {
        public class Main
        {
            [JsonProperty("temperatura")]
            public float Temperatura;

            [JsonProperty("odczuwalna")]
            public float Odczuwalna;

            [JsonProperty("wilgotnosc")]
            public int Wilgotnosc;
        }
    }
}

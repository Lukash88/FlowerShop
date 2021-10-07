using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop
{
    public class Weather
    {
        public DateTime Data { get; set; }

        public int TemperaturaC { get; set; }

        public int TemperaturaF => 32 + (int)(TemperaturaC / 0.5556);

        public string Podsumowanie { get; set; }
    }
}

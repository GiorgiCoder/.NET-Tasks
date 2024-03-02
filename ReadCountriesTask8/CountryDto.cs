using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks.ReadCountriesTask8
{
    public class CountryDto
    {
        public Name name { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public double[] latlng { get; set; } = new double[2];
        public double area { get; set; }
        public long population { get; set; }

    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public object nativeName { get; set; }
    }
}

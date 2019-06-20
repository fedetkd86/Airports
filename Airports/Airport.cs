using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports
{
    public class Airport
    {

        public Airport() { }
        public Airport(string value)
        {
            Name = value;
        }

        public Guid guid { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

    }
}

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

        public override bool Equals(object obj)
        {
            var airport = obj as Airport;
            return airport != null &&
                   Name == airport.Name;
        }
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}

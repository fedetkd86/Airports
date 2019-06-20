using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports
{
    public class ComboLoader
    {
        public string[] LoadOriginComboBox()
        {
            string[] keyNames = new string[SingletonAirports.airportsDictionary.Keys.Count()];
            int index = 0;
            foreach (Airport name in SingletonAirports.airportsDictionary.Keys.ToArray())
            {
                keyNames[index] = SingletonAirports.airportsDictionary.Keys.ElementAt(index).Name.ToString();
                index++;
            }

            return keyNames;
        }
        
        public string[] LoadDestinationsComboBox(string originName)
        {
            List<Airport> airports = new List<Airport>();
            bool found = SingletonAirports.airportsDictionary.TryGetValue(new Airport(originName), out airports);
            if (!found)
            {
                throw new Exception("No airports");
            }
            string[] airportNames = new string[airports.Count];
            for (int i = 0; i < airportNames.Length; ++i)
            {
                airportNames[i] = airports[i].Name;
            }

            return airportNames;
            //cmbDestinations.DataSource = airportNames;
            //cmbDestinations.SelectedItem = 0;
        }
    }
}

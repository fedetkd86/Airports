using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Airports
{
    public sealed class SingletonAirports
    {
        private static SingletonAirports instance = null;
        private static readonly object padlock = new object();

        public static Dictionary<Airport, List<Airport>> airportsDictionary = new Dictionary<Airport, List<Airport>>();
        public Guid Id { get; set; }
        private SingletonAirports()
        {
            LoadAirportDictionary("Airports.xml");
            Id = Guid.NewGuid();
        }

        public static SingletonAirports Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonAirports();
                    }
                    return instance;
                }
            }
        }

        public static void LoadAirportDictionary(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            var airportsXml = xmlDoc.Descendants("Airport");

            foreach (XElement destination in airportsXml)
            {
                string origin = destination.Attribute("origin").Value;
                var connections = destination.Elements("Destino");

                List<Airport> airportConnections = new List<Airport>();
                foreach (XElement con in connections)
                {
                    airportConnections.Add(new Airport(con.Value));
                }
                airportsDictionary.Add(new Airport(origin), airportConnections);
            }            
        }
    }
}

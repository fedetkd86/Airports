using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Tests
{
    [TestClass()]
    public class SingletonAirportsTests
    {
        [TestMethod()]
        public void LoadAirportDictionaryTest()
        {
            SingletonAirports singletonAirport1 = SingletonAirports.Instance;
            SingletonAirports singletonAirport2= SingletonAirports.Instance;

            Assert.IsTrue(singletonAirport1.Id.ToString() == singletonAirport2.Id.ToString());
        }
    }
}
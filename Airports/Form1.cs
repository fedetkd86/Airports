using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Airports
{
    public partial class Form1 : Form
    {
        Airport airport = new Airport();
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SingletonAirports singletonAirports = SingletonAirports.Instance;
            LoadOriginComboBox();            

        }

        private void LoadOriginComboBox()
        {
            string[] keyNames = new string[SingletonAirports.airportsDictionary.Keys.Count()];
            int index = 0;
            foreach (Airport name in SingletonAirports.airportsDictionary.Keys.ToArray())
            {
                keyNames[index] = SingletonAirports.airportsDictionary.Keys.ElementAt(index).Name.ToString();
                index++;
            }
            cmbOrigin.DataSource = keyNames;
            cmbOrigin.DisplayMember = keyNames.ToString();         

        }

        private void LoadDestinationsComboBox(string originName)
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
            cmbDestinations.DataSource = airportNames;
            cmbDestinations.SelectedItem = 0;
        }

        private void cmbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = cmbOrigin.SelectedItem.ToString();
            LoadDestinationsComboBox(selectedCity);
        }
    }
}

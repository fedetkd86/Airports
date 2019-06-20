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
        ComboLoader loader = new ComboLoader();
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
            string[] keyNames = loader.LoadOriginComboBox();
            cmbOrigin.DataSource = keyNames;
            cmbOrigin.DisplayMember = keyNames.ToString();    
        }

        private void LoadDestinationsComboBox(string originName)
        {
            string[] destinations = loader.LoadDestinationsComboBox(originName);
            cmbDestinations.DataSource = destinations;
            cmbDestinations.SelectedItem = 0;
        }

        private void cmbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = cmbOrigin.SelectedItem.ToString();
            LoadDestinationsComboBox(selectedCity);
        }
    }
}

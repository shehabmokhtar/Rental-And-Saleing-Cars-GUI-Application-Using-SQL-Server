using rental_cars_application.core.utilities;
using rental_cars_application.modules.settings.presentation.forms;
using rental_cars_application.modules.support.presentation.forms;
using rental_cars_application.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.home.presentation
{
    public partial class CustomerHomeForm : Form
    {


        public CustomerHomeForm()
        {
            InitializeComponent();
         Utilities.GenerateVehiclesItemsList(false,flowLayoutPanel1.Controls);
        }

        private void CustomerHomeForm_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Customer support button
        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the support form
            CustomerSupportForm customerSupportForm = new CustomerSupportForm();
            Utilities.NavigateToNewForm(this, customerSupportForm);
        }

        // Customer settings button
        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to the settins form
            CustomerSettingsForm customerSettingsForm= new CustomerSettingsForm();
            Utilities.NavigateToNewForm(this, customerSettingsForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

using rental_cars_application.core.core_repo;
using rental_cars_application.core.services;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.data.repositories.employe_repo;
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

namespace rental_cars_application.modules.home.presentation.forms.customer
{
    public partial class SetCurrentLocationForm : Form
    {
        CoreRepoImpl CoreRepoImpl = new CoreRepoImpl();
        public SetCurrentLocationForm()
        {
            InitializeComponent();

        }

        // Set current location button
        private void button1_Click(object sender, EventArgs e)
        {
           string r =  CoreRepoImpl.UpdateCustomerCurrentLocation(textBox1.Text);

            if(r == string.Empty)
            {
                CustomerHomeForm customerHomeForm = new CustomerHomeForm();
                Utilities.NavigateToNewForm(this,customerHomeForm);
            }
            else
            {
                MessageBox.Show(r);
            }
        }


        // Country
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void SetCurrentLocationForm_Load(object sender, EventArgs e)
        {

        }
    }
}

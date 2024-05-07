using rental_cars_application.core.utilities;
using rental_cars_application.modules.authantication.data.models;
using rental_cars_application.modules.home.data.models;
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

namespace rental_cars_application.modules.home.presentation.forms.employee
{
    public partial class TrackVehicleForm : Form
    {
        private UserModel TentantInfo;
        private int customerId;
        String vehicleCurrentLocation;

        public TrackVehicleForm(int customerId,String vehicleCurrentLocation)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.vehicleCurrentLocation = vehicleCurrentLocation;
            InitFormData();
            
        }
        private void TrackVehicleForm_Load(object sender, EventArgs e)
        {

        }

        // Vehicle current location
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Tenant id
        private void label12_Click(object sender, EventArgs e)
        {

        }

        // Tenant fist name
        private void label6_Click(object sender, EventArgs e)
        {

        }

        // Tenant last name
        private void label9_Click(object sender, EventArgs e)
        {

        }

        // Tenant email
        private void label10_Click(object sender, EventArgs e)
        {

        }

        // Tenanat phone number
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool GetTenantInfo(){

            Tuple<string, UserModel> result = GetUsersDataFromDB.GetUserById(customerId);

            if(result.Item1 == string.Empty)
            {
                TentantInfo = result.Item2;
                return true;
            }
            else
            {
                MessageBox.Show(result.Item1);
                return false; 

            }
        
        
        }
    private void InitFormData()
        {
            if(GetTenantInfo() == true)
            {
                label2.Text = vehicleCurrentLocation;
                label20.Text = TentantInfo.firstName[0].ToString().ToUpper();
                label19.Text = TentantInfo.identificationCardNumber;
                label18.Text = TentantInfo.firstName + " "+ TentantInfo.lastName;
                label15.Text = TentantInfo.phoneNumber;
                label13.Text = TentantInfo.email;





            }
            else
            {
                MessageBox.Show("Error when getting tenant info");
            }
        }

        // letter
        private void label20_Click(object sender, EventArgs e)
        {

        }

        // id
        private void label19_Click(object sender, EventArgs e)
        {

        }

        // First name and surname
        private void label18_Click(object sender, EventArgs e)
        {

        }

        // phone number
        private void label15_Click(object sender, EventArgs e)
        {

        }

        // email
        private void label13_Click(object sender, EventArgs e)
        {

        }

        // back button
        private void button2_Click(object sender, EventArgs e)
        {
            CustomerHomeForm chf = new CustomerHomeForm();
            Utilities.NavigateToNewForm(this,chf);
        }
    }
}

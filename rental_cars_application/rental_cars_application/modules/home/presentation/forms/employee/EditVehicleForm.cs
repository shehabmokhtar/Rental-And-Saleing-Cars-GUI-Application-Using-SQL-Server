using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.data.models;
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

namespace rental_cars_application.modules.home.presentation.forms.employee
{
    public partial class EditVehicleForm : Form
    {
        private VehiclesRepoImpl vehiclesRepoImpl = new VehiclesRepoImpl();

        String imageUrl;
        String manufacturer;
        String model;
        String year;
        String color;
        String droveKilometers;
        String transmission;
        String engineCapacity;
        float salePrice;
        float dailyRentalPrice;
        String currentLocation;
        private VehicleModel vehicle;
        private bool isForSale;

        public EditVehicleForm(VehicleModel vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            isForSale = vehicle.salePrice == 0? false : true;
            InitFormData();
        }

        // Back button
        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
            Utilities.NavigateToNewForm(this,employeeHomeForm);
        }

        // image text box
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            imageUrl = textBox5.Text;
            
        }

        // Manufacturer
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            vehicle.manufacturer = textBox4.Text;

        }

        // Model
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            vehicle.model= textBox3.Text;

        }

        // Year
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            vehicle.year =  textBox2.Text;

        }

        // Color
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            vehicle.color = textBox1.Text;

        }

        // Drove Kilometers
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            vehicle.droveKilometers = textBox11.Text;

        }

        // Transmission
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            vehicle.transmission =  textBox10.Text;

        }

        // Engine capacity
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            vehicle.engineCc =  textBox9.Text;

        }

        // Sale price
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            float salePrice;
            float.TryParse(textBox7.Text, out salePrice);
            vehicle.salePrice= salePrice;
        }

        // Daily rental price
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            float dailyRentalPrice;
            float.TryParse(textBox7.Text, out dailyRentalPrice);
            vehicle.dailyRentalPrice = dailyRentalPrice;


        }

        // Current location
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            vehicle.currentLocation = textBox6.Text;

        }

        // Edit button
        private void button2_Click(object sender, EventArgs e)
        {
            if (isForSale)
            {
               vehicle.dailyRentalPrice= 0;
            }
            else if (!isForSale)
            {
                vehicle.salePrice = 0;
            }
;
            string result = vehiclesRepoImpl.UpdateVehicleById(vehicle);

            if (result == string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Vehicle Edited Successfully", "Success", MessageBoxButtons.OK);

                if (dialogResult == DialogResult.OK)
                {
                    EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
                    Utilities.NavigateToNewForm(this, employeeHomeForm);
                }
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void EditVehicleForm_Load(object sender, EventArgs e)
        {

        }


        // For sale radio button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isForSale = radioButton2.Checked;

        }

        // For rent radio button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                        isForSale = radioButton1.Checked;

        }

        private void InitFormData()
        {
            radioButton2.Checked = isForSale;
            radioButton1.Checked = isForSale;
            textBox5.Text = vehicle.imageUrl;
            textBox4.Text = vehicle.manufacturer;
            textBox3.Text = vehicle.model;
            textBox2.Text = vehicle.year;
            textBox1.Text = vehicle.color;
            textBox11.Text = vehicle.droveKilometers;
            textBox10.Text = vehicle.transmission;
            textBox9.Text = vehicle.engineCc;
            textBox8.Text = vehicle.salePrice.ToString();
            textBox7.Text = vehicle.dailyRentalPrice.ToString();
            textBox6.Text = vehicle.currentLocation;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

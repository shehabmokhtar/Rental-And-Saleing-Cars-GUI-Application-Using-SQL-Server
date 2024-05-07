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

namespace rental_cars_application.modules.home.presentation.forms
{
    public partial class AddNewVehicleForm : Form
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
         
        bool isForSale = false;

        public AddNewVehicleForm()
        {
            InitializeComponent();
        }

        // Back to home screen
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Loading....";   
            EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
            Utilities.NavigateToNewForm(this, employeeHomeForm);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // For sale
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isForSale = radioButton2.Checked;
        }

        // For rent
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isForSale = radioButton2.Checked;
        }

        // color textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            color = textBox1.Text;
        }

        // image textbox
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            imageUrl = textBox5.Text;
        }

        // manufacturer textbox
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            manufacturer = textBox4.Text;
        }

        // model textbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            model = textBox3.Text;
        }

        // year textbox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            year = textBox2.Text;
        }

        // drove kilometers textbox
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            droveKilometers = textBox11.Text;   
        }

        // transmission textbox
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            transmission = textBox10.Text;   
        }

        // engine capacity textbox
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            engineCapacity = textBox9.Text;
        }

        // sale price textbox
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(textBox8.Text, out salePrice);
        }

        // sale rental price textbox
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
            float.TryParse(textBox7.Text,out dailyRentalPrice);
        }

        // current location textbox
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            currentLocation = textBox6.Text;
        }


        // Add new vehicle button
        private void button2_Click(object sender, EventArgs e)
        {          if (isForSale)
            {
                dailyRentalPrice = 0;
            }
            else if(!isForSale){
                salePrice = 0;
            }

                      VehicleModel vehicleModel = new VehicleModel(0,AppData.userData.userId,0,imageUrl,manufacturer,model,year,color,droveKilometers,transmission,engineCapacity,salePrice,dailyRentalPrice,1,currentLocation);

           string result = vehiclesRepoImpl.AddNewVehicle(vehicleModel);

            if(result == string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Vehicle Added Successfully","Success",MessageBoxButtons.OK);
                
                if (dialogResult == DialogResult.OK) {
                    EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
                    Utilities.NavigateToNewForm(this, employeeHomeForm);
                }
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void AddNewVehicleForm_Load(object sender, EventArgs e)
        {

        }
    }
}

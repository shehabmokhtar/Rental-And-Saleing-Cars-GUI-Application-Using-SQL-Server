using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.get_data;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.data.repositories.employe_repo;
using rental_cars_application.modules.invoices.data.repositories;
using rental_cars_application.modules.receipts.data.repositories;
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
    public partial class BuyForm : Form
    {
        private VehiclesRepoImpl vehiclesRepoImpl = new VehiclesRepoImpl();

        private VehicleModel vehicle;
        private const float taxes = 0;
        private const float discount = 0;
        private float totalAmount= 0;
        private string note = "";
        private string status = "";

        private InvoicesRepoImpl invoicesRepoImpl = new InvoicesRepoImpl();
        public BuyForm(VehicleModel vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            label6.Text = discount.ToString();
            label7.Text = taxes.ToString();
            totalAmount = (taxes + vehicle.salePrice) - discount;


        }

        private void BuyOrRentForm_Load(object sender, EventArgs e)
        {

        }

        // Back button
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
            
        // Buy button
        private void button2_Click(object sender, EventArgs e)
        {
            string r = GetTransactionsFromDB.AddTransaction(vehicle.employeeId,vehicle.id,status,vehicle.transmission,note,totalAmount,AppData.userData.paymentMethod);
            vehiclesRepoImpl.UpdateAvailability(vehicle.id);
            if (r == string.Empty)
            {
                string r2 = invoicesRepoImpl.AddNewInvoice(vehicle.employeeId, totalAmount,taxes,discount,note);    
                if (r2 == string.Empty)
                {
                     DialogResult dr = MessageBox.Show("Done","Success",MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {

                    CustomerHomeForm customerHomeForm = new CustomerHomeForm();
                    Utilities.NavigateToNewForm(this, customerHomeForm);
                }
                }
                else
                {
                    MessageBox.Show(r2);
                }
            }
            else
            {
                MessageBox.Show(r);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            note = textBox1.Text;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string r = GetTransactionsFromDB.AddTransaction(vehicle.employeeId, vehicle.id, status, vehicle.transmission, note, totalAmount, AppData.userData.paymentMethod);
            vehiclesRepoImpl.UpdateAvailability(vehicle.id);
            if (r == string.Empty)
            {
                string r2 = invoicesRepoImpl.AddNewInvoice(vehicle.employeeId, totalAmount, taxes, discount, note);
                if (r2 == string.Empty)
                {
                    DialogResult dr = MessageBox.Show("Done", "Success", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {

                        CustomerHomeForm customerHomeForm = new CustomerHomeForm();
                        Utilities.NavigateToNewForm(this, customerHomeForm);
                    }
                }
                else
                {
                    MessageBox.Show(r2);
                }
            }
            else
            {
                MessageBox.Show(r);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerHomeForm customerHomeForm = new CustomerHomeForm();
            Utilities.NavigateToNewForm(this, customerHomeForm);
        }
    }
}

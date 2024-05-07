using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.get_data;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.data.repositories.employe_repo;
using rental_cars_application.modules.home.presentation.items;
using rental_cars_application.modules.invoices.data.repositories;
using rental_cars_application.modules.messages.data.repositories;
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
    public partial class RentForm : Form
    {
        private VehiclesRepoImpl vehiclesRepoImpl= new VehiclesRepoImpl();
        private VehicleModel vehicle;
        private const float taxes = 10;
        private const float discount = 30;
        private float totalAmount = 0;
        private string note = "";
        private string status = "";
        private int numberOfRentalDays = 1;
        private InvoicesRepoImpl invoicesRepoImpl = new InvoicesRepoImpl();


        public RentForm(VehicleModel vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            label6.Text = "- "+discount.ToString();
            label7.Text = taxes.ToString();
            label10.Text = totalAmount.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerHomeForm customerHomeForm   = new CustomerHomeForm();   
            Utilities.NavigateToNewForm(this,customerHomeForm);
        }

        private void RentForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            totalAmount = ((numberOfRentalDays * vehicle.dailyRentalPrice)+ taxes)- discount;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // number of days
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberOfRentalDays = int.Parse(comboBox1.SelectedItem.ToString());        }
        // discount
        private void label6_Click(object sender, EventArgs e)
        {

        }

        // Taxes
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            note = textBox1.Text;
        }
    }
}

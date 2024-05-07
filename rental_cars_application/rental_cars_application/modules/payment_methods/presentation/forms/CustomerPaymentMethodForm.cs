using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.presentation.forms.customer;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.payment_methods.data.repositories;
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

namespace rental_cars_application.modules.payment_methods.presentation.forms
{
    public partial class CustomerPaymentMethodForm : Form
    {

        private bool isSale;
        private string paymentMethod;
        private PaymentMethodsRepoImpl paymentMethodsRepoImpl = new PaymentMethodsRepoImpl();
        private VehicleModel vehicle;
        public CustomerPaymentMethodForm(VehicleModel vehicle)
        {
            InitializeComponent();
            this.vehicle = vehicle;
            isSale = vehicle.salePrice != 0;

        }

        // Add payment method
        private void button1_Click(object sender, EventArgs e)
        {
            paymentMethod = textBox1.Text;
           string r = paymentMethodsRepoImpl.AddCustomerPaymentMethod(paymentMethod);

            if(r == string.Empty)
            {
                CustomerHomeForm customerHomeForm = new CustomerHomeForm();

                if (isSale)
                {
                    BuyForm buyOrRentForm = new BuyForm(vehicle);
                    Utilities.NavigateToNewForm(customerHomeForm, buyOrRentForm);
                }
                else
                {
                    RentForm rentForm = new RentForm(vehicle);
                    Utilities.NavigateToNewForm(customerHomeForm, rentForm);
                }
            }
            else
            {
                MessageBox.Show(r);
            }
        }

        // payment method
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

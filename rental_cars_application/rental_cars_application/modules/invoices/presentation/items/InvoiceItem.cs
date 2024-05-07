using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.presentation.items;
using rental_cars_application.modules.invoices.data.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.invoices.presentation.items
{
    public partial class InvoiceItem : UserControl
    {
        InvoiceModel invoice;
        public InvoiceItem(InvoiceModel invoice)
        {
            InitializeComponent();
            this.invoice = invoice;
            label18.Text = invoice.invoiceId.ToString();
            label19.Text = invoice.customerId.ToString();
            label20.Text = invoice.employeeId.ToString();
            label13.Text = "- "+invoice.discounts.ToString();
            label14.Text = invoice.taxes.ToString();
            label15.Text = invoice.paymentMethod;
            label16.Text = invoice.totalAmount.ToString();
            label17.Text = invoice.notes;
            label3.Text = invoice.invoiceDate;





        }

        private void InvoiceItem_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

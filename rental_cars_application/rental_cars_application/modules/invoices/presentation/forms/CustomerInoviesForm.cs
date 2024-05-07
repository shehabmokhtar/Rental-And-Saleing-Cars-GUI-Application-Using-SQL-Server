using rental_cars_application.modules.invoices.data.models;
using rental_cars_application.modules.invoices.data.repositories;
using rental_cars_application.modules.invoices.presentation.items;
using rental_cars_application.modules.settings.presentation.forms;
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

namespace rental_cars_application.modules.invoices.presentation.forms
{
    public partial class CustomerInoviesForm : Form
    {
        private InvoicesRepoImpl invoicesRepoImpl = new InvoicesRepoImpl(); 
        public CustomerInoviesForm()
        {
            InitializeComponent();
            LoadInvoicesFlowLayoutPanel();
        }

        private void InoviesForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerSettingsForm customerSettingsForm = new CustomerSettingsForm();
            Utilities.NavigateToNewForm(this,customerSettingsForm);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void LoadInvoicesFlowLayoutPanel() {

            string r = invoicesRepoImpl.GetCustomerInvoices();

            if(r == string.Empty)
            {
                foreach (InvoiceModel invoice in InvoicesRepoImpl.customerInvoices) {

                    InvoiceItem invoiceItem = new InvoiceItem(invoice);

                    flowLayoutPanel1.Controls.Add(invoiceItem);
                }
            }
            else
            {
                MessageBox.Show(r);
            }
            
        
        }
    }
}

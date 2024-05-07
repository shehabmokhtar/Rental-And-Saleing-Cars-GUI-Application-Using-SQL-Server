using rental_cars_application.modules.receipts.data.models;
using rental_cars_application.modules.receipts.data.repositories;
using rental_cars_application.modules.receipts.presentation.items;
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

namespace rental_cars_application.modules.receipts.presentation.forms
{
    public partial class CustomerReceiptsForm : Form
    {
        private ReceiptsRepoImpl receiptsRepo = new ReceiptsRepoImpl(); 
        public CustomerReceiptsForm()
        {
            InitializeComponent();
            CreateRecieptsList();
            
        }

        private void CustomerReceiptsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerSettingsForm customerSettingsForm = new CustomerSettingsForm();
            Utilities.NavigateToNewForm(this, customerSettingsForm);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateRecieptsList() {

            string r = receiptsRepo.GetCustomerReceipts();

            if(r == string.Empty) {
            
                foreach(ReceiptModel rm in ReceiptsRepoImpl.customerReceipts)
                {
                    ReceiptUserControl ruc = new ReceiptUserControl(rm);
                    flowLayoutPanel1.Controls.Add(ruc);
                }

            } else
            {
                MessageBox.Show(r);
            }
         }
    }
}

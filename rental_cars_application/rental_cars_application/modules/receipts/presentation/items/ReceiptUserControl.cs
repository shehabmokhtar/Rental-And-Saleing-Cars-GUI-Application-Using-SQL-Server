using rental_cars_application.modules.receipts.data.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.receipts.presentation.items
{
    public partial class ReceiptUserControl : UserControl
    {
        ReceiptModel receipt;

        public ReceiptUserControl(ReceiptModel receipt)
        {
            InitializeComponent();
            this.receipt = receipt;
            label18.Text = receipt.receiptId.ToString();
            label19.Text = receipt.invoiceId.ToString();
            label17.Text = receipt.notes;
            label3.Text = receipt.date;


        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}

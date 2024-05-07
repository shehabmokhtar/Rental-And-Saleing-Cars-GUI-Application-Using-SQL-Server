using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.invoices.presentation.forms;
using rental_cars_application.modules.receipts.presentation.forms;
using rental_cars_application.modules.settings.presentation.items;
using rental_cars_application.modules.support.presentation.forms;
using rental_cars_application.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.settings.presentation.forms
{
    public partial class CustomerSettingsForm : Form
    {
        public CustomerSettingsForm()
        {
            InitializeComponent();
            ProfileItem profileItem = new ProfileItem(AppData.userData);
           flowLayoutPanel1.Controls.Add(profileItem);
        }

        private void CustomerSettingsForm_Load(object sender, EventArgs e)
        {

        }

        // Customer home button
        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to home form
            CustomerHomeForm chf = new CustomerHomeForm();
            Utilities.NavigateToNewForm(this, chf);
        }

        // Customer support button
        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the support form
            CustomerSupportForm customerSupportForm = new CustomerSupportForm();
            Utilities.NavigateToNewForm(this, customerSupportForm);
        }

        // Logout button
        private void button3_Click(object sender, EventArgs e)
        {
            SignInForm sif= new SignInForm();
            Utilities.NavigateToNewForm(this, sif);
        }

        // Invoice button
        private void button5_Click(object sender, EventArgs e)
        {
            // Navigate to the invoice form
            CustomerInoviesForm  cif= new CustomerInoviesForm();
            Utilities.NavigateToNewForm(this, cif);
        }

        // Receits
        private void button6_Click(object sender, EventArgs e)
        {
            CustomerReceiptsForm crf= new CustomerReceiptsForm();
            Utilities.NavigateToNewForm(this, crf);
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using rental_cars_application.core.get_data;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.settings.presentation.items;
using rental_cars_application.modules.support.presentation.forms;
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

namespace rental_cars_application.modules.settings.presentation.forms
{
    public partial class EmployeeSettingsForm : Form
    {
        public EmployeeSettingsForm()
        {
            InitializeComponent();
            ProfileItem profileItem = new ProfileItem(AppData.userData);
            flowLayoutPanel1.Controls.Add(profileItem);
        }

        // Home button
        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to the home form
            EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
            Utilities.NavigateToNewForm(this, employeeHomeForm);
        }

        // Support button
        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the support form
            EmployeeSupportForm employeeSupportForm = new EmployeeSupportForm();    
            Utilities.NavigateToNewForm(this, employeeSupportForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetVehiclesDataFromDB.GetVehicles());
            MessageBox.Show(GetVehiclesDataFromDB.vehicles.Count().ToString());

        }


        // Logout button
        private void button3_Click_1(object sender, EventArgs e)
        {
            // Navigate to the support form
            SignInForm sif = new SignInForm();
            Utilities.NavigateToNewForm(this, sif);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmployeeSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}

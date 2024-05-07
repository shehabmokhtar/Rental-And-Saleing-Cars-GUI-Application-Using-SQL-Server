using rental_cars_application.modules.home.presentation;
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

namespace rental_cars_application.modules.support.presentation.forms
{
    public partial class EmployeeSupportForm : Form
    {
        public EmployeeSupportForm()
        {
            InitializeComponent();
        }

        // Settings button
        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to the settings form
            EmployeeSettingsForm employeeSettingsForm = new EmployeeSettingsForm();
            Utilities.NavigateToNewForm(this, employeeSettingsForm);
        }

        // Home button
        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to the home form
            EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm();
            Utilities.NavigateToNewForm(this, employeeHomeForm);
        }
    }
}

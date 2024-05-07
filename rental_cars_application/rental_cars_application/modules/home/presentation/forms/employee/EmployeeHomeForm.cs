using rental_cars_application.core.get_data;
using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.data.repositories.employe_repo;
using rental_cars_application.modules.home.presentation.forms;
using rental_cars_application.modules.home.presentation.items;
using rental_cars_application.modules.settings.presentation.forms;
using rental_cars_application.modules.support.presentation.forms;
using rental_cars_application.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace rental_cars_application.modules.home.presentation
{
    public partial class EmployeeHomeForm : Form
    {
        private VehiclesRepoImpl vehiclesRepoImpl = new VehiclesRepoImpl();

        public EmployeeHomeForm()
        {
            InitializeComponent();
                flowLayoutPanel1.Visible = false;
          Utilities.GenerateVehiclesItemsList(true,flowLayoutPanel1.Controls);
            flowLayoutPanel1.Visible = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        // Support button
        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the support form
            EmployeeSupportForm employeeSupportForm = new EmployeeSupportForm();
            Utilities.NavigateToNewForm(this, employeeSupportForm);
        }


        // Settings button
        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to the settings form
            EmployeeSettingsForm employeeSettingsForm= new EmployeeSettingsForm();
            Utilities.NavigateToNewForm(this, employeeSettingsForm);
        }

        private void EmployeeHomeForm_Load(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            AddNewVehicleForm addNewVehicleForm = new AddNewVehicleForm();
            Utilities.NavigateToNewForm(this, addNewVehicleForm);

        }
    }

}

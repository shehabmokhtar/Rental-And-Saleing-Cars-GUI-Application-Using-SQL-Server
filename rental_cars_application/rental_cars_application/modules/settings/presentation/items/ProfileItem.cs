using rental_cars_application.modules.authantication.data.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.settings.presentation.items
{
    public partial class ProfileItem : UserControl
    {
        UserModel userModel;

        public ProfileItem(UserModel userModel)
        {
            InitializeComponent();
            this.userModel = userModel;
            label1.Text = userModel.firstName[0].ToString().ToUpper();
            label2.Text = userModel.identificationCardNumber;
            label6.Text = userModel.phoneNumber;
            label7.Text = userModel.email;
            label3.Text = userModel.firstName + " " + userModel.lastName;   



        }

        private void ProfileItem_Load(object sender, EventArgs e)
        {

        }

        // Letter
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // id
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // phone number
        private void label6_Click(object sender, EventArgs e)
        {

        }

        // email
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

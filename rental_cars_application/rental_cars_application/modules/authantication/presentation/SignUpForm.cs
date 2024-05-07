using rental_cars_application.core.utilities;
using rental_cars_application.modules.authantication.data.repository;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application
{
    public partial class SignUpForm : Form
    {
        private AuthanticationRepoImpl authRepoImpl = new AuthanticationRepoImpl();

        public SignUpForm()
        {
            InitializeComponent();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        // Phone number
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
        // Full name text box
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        // Email text box
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        // Password
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Birthday
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Address
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        // Back button
        private void button2_Click(object sender, EventArgs e)
        {
        SignInForm signInForm = new SignInForm();
         Utilities.NavigateToNewForm(this,signInForm);
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        // Sign up button
        private void button1_Click(object sender, EventArgs e)
        {

            // Assign textboxs to variables
         string first_name = textBox6.Text;
         string last_name = textBox5.Text;
         string email = textBox7.Text;
         string password = textBox3.Text;
         string phone_number = textBox4.Text;
         string birthday = textBox2.Text;
         string address = textBox1.Text;
         string current_location = "";
         string payment_method = "";
         string identification_card_number = textBox8.Text;
         string role = "customer";

            string checkTextBoxIsEmpty = Utilities.CheckTextBoxIsNullOrEmpty(
    new List<string>
{
    first_name,
    last_name,
     phone_number,
    email,
    password,
      identification_card_number,
          address,
    birthday

 
},

           new List<string>
{
    "First Name is required.",
    "Last Name is required.",
    "Phone Number is required.",
    "Email is required.",
    "Password is required.",
    "Identification Card Number is required.",
       "Address is required.",

    "Birthday is required."
 
});


            // sign up method
            string responseMessage = authRepoImpl.SignUp(first_name, last_name, email, phone_number,password,birthday, address, current_location, payment_method, identification_card_number, role);

        if(checkTextBoxIsEmpty == string.Empty)
            {
                if (responseMessage == string.Empty)
                {
                    GetUsersDataFromDB.GetUserData(phone_number);
                    CustomerHomeForm customerHomeForm = new CustomerHomeForm();
                    Utilities.NavigateToNewForm(this, customerHomeForm);
                }
                else
                {
                    // Message box
                    MessageBox.Show(responseMessage);
                }
            }
            else
            {
                MessageBox.Show(checkTextBoxIsEmpty);
            }

    }

        // Id number button
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

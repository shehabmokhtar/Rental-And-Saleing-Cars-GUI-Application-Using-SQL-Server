using rental_cars_application.core.utilities;
using rental_cars_application.modules.authantication.data.repository;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.home.presentation.forms.customer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rental_cars_application
{
    public partial class SignInForm : Form
    {
        AuthanticationRepoImpl authrepoImp = new AuthanticationRepoImpl();

        public SignInForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Email text filed
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Sign in button
        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = textBox1.Text;
            string password = textBox2.Text;
            string m = authrepoImp.SignIn(phoneNumber,password);
            string checkTextBoxIsEmpty = Utilities.CheckTextBoxIsNullOrEmpty(
                new List<string> {phoneNumber,password}, 
                new List<string> {"Mobile phone is required", "Password is required" });

         if(checkTextBoxIsEmpty == string.Empty)
            {
                   if (m == string.Empty)
            {
                    NavigateToHomeForm();
            }
            else
            {
                MessageBox.Show(m);
            }
            }
            else{
                MessageBox.Show(checkTextBoxIsEmpty);
            }
        }

        
        // Password text filed
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }

        // Sign up button
        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            Utilities.NavigateToNewForm(this,signUpForm);
        }



        // Navigate to the home form
        private void NavigateToHomeForm() {
        
            if(AppData.userData.role == "customer")
            {
                SetCurrentLocationForm sc = new SetCurrentLocationForm();
                Utilities.NavigateToNewForm(this, sc);
            }
            else if(AppData.userData.role == "employee")
            {
                EmployeeHomeForm employeeHomeForm = new EmployeeHomeForm(); 
                Utilities.NavigateToNewForm(this, employeeHomeForm);
            }
            else if (AppData.userData.role == "support")
            {
                SupportForm sf = new SupportForm();
                Utilities.NavigateToNewForm(this, sf);
            }
            else
            {
                MessageBox.Show("There is an problem, Contact with support\nEmail: example@gmail.com");
            }
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

    
}

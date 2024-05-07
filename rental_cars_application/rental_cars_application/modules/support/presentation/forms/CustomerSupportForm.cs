using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.messages.data.models;
using rental_cars_application.modules.messages.data.repositories;
using rental_cars_application.modules.settings.presentation.forms;
using rental_cars_application.modules.support.presentation.items;
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
    public partial class CustomerSupportForm : Form
    {
        private static MessageRepoImpl messageRepoImpl = new MessageRepoImpl();    
        public CustomerSupportForm()
        {
            InitializeComponent();
            CreateMessagesItems(flowLayoutPanel1.Controls);


        }

        private void CustomerSupportForm_Load(object sender, EventArgs e)
        {

        }

        // Customer Home button
        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to home form
            CustomerHomeForm chf = new CustomerHomeForm();
            Utilities.NavigateToNewForm(this, chf);
        }

        // Customer settings button 
        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to settings form
            CustomerSettingsForm csf = new CustomerSettingsForm();
            Utilities.NavigateToNewForm(this, csf);
        }

        // send message
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static void CreateMessagesItems(dynamic controls)
        {
            string r  = messageRepoImpl.GetCustomerMessages();

            if(r == string.Empty)
            {
                foreach(MessageModel m in MessageRepoImpl.messages)
                {
                    MessageUserControl messageUserControl = new MessageUserControl(m);
                    controls.Add(messageUserControl);

                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // send button
        private void button3_Click(object sender, EventArgs e)
        {
            string r = messageRepoImpl.AddMessage(false, AppData.userData.userId, textBox1.Text);

            if(r == string.Empty)
            {
                messageRepoImpl.GetCustomerMessages();
                textBox1.Text = "";
                this.Hide();
                CustomerHomeForm c = new CustomerHomeForm();
                c.Show();
                MessageBox.Show("Your message driven successfully");

            }
            else
            {
                MessageBox.Show(r);
            }
        }
    }
}

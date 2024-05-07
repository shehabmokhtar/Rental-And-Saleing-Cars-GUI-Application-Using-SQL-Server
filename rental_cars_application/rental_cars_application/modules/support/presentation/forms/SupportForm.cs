using rental_cars_application.modules.messages.data.models;
using rental_cars_application.modules.messages.data.repositories;
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
    public partial class SupportForm : Form
    {
        MessageRepoImpl MessageRepoImpl = new MessageRepoImpl();    
        public SupportForm()
        {
            InitializeComponent();
            CreateMessagesItems();
        }

        // Logout button
        private void button2_Click(object sender, EventArgs e)
        {
            SignInForm sif = new SignInForm();
            Utilities.NavigateToNewForm(this, sif);
        }

        private void SupportForm_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateMessagesItems()
        {
            string r = MessageRepoImpl.GetSupportMessages();

            if (r == string.Empty)
            {
                foreach (MessageModel m in MessageRepoImpl.messages)
                {
                    MessageUserControl messageUserControl = new MessageUserControl(m);  
                 flowLayoutPanel1.Controls.Add(messageUserControl);

                }
            }
            else
            {
                MessageBox.Show(r);
            }
        }
    }
}

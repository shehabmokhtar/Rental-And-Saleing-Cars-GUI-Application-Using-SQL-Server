using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.messages.data.models;
using rental_cars_application.modules.messages.data.repositories;
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

namespace rental_cars_application.modules.support.presentation.items
{
    public partial class MessageUserControl : UserControl
    {
        MessageRepoImpl messageRepoImpl = new MessageRepoImpl();
        MessageModel messageModel;

        public MessageUserControl(MessageModel messageModel)
        {
            InitializeComponent();
            this.messageModel = messageModel;
            if (AppData.userData.role == "customer")
            {
                button1.Visible = false;
                textBox1.Visible = false;

            }
            label3.Text = messageModel.customerId.ToString();
            label4.Text = messageModel.messageBody;
        }

        private void MessageUserControl_Load(object sender, EventArgs e)
        {

        }

        // replay text box
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // replay button
        private void button1_Click(object sender, EventArgs e)
        {
                string r = messageRepoImpl.UpdateReplayMessage(messageModel.id);
            string add_r = messageRepoImpl.AddMessage(true,messageModel.customerId,textBox1.Text);

            if(r == string.Empty && add_r == string.Empty)
            {
         

                DialogResult dr =                 MessageBox.Show("We received your message\nThank you.","Success",MessageBoxButtons.OK);

                if(dr == DialogResult.OK)
                {
                    string rr =  messageRepoImpl.GetSupportMessages();

                    if(rr == string.Empty) {

                        SupportForm sf = new SupportForm();
                        sf.Hide();
                        sf.Show();
                    }
                    else
                    {
                        MessageBox.Show(rr);
                    }
                }
           }
            else
            {
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Customer id
        private void label3_Click(object sender, EventArgs e)
        {

        }

        // message
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

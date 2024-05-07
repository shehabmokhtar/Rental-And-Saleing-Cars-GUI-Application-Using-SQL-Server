using rental_cars_application.core.utilities;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.messages.data.models;
using rental_cars_application.modules.messages.data.repositories;
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
    public partial class MessageItemm : UserControl
    {
        private MessageRepoImpl messageRepoImpl = new MessageRepoImpl();

        private MessageModel messageModel;
        public MessageItemm(MessageModel messageModel)
        {
            InitializeComponent();
            // if the role is customer text filed and replay button will be unvisable
            if(AppData.userData.role == "customer")
            {
                textBox1.Visible = false;
                button1.Visible = false;
            }
            messageRepoImpl.GetSupportMessages();
            label1.Text = messageModel.messageBody;
            this.messageModel = messageModel;
        }

        private void CustomerChatItem_Load(object sender, EventArgs e)
        {

        }

        // Replay button
        private void button1_Click(object sender, EventArgs e)
        {
        }

        // Message body
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Replay text textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

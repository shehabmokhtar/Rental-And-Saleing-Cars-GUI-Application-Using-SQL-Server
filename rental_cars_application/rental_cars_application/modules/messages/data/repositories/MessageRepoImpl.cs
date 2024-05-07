using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.messages.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.modules.messages.data.repositories
{
    internal class MessageRepoImpl : MessageRepo
    {
        public static List<MessageModel> messages = new List<MessageModel>();
        private messagesTableAdapter messagesTableAdapter = new messagesTableAdapter();
        // Get customer messages
        public override string GetCustomerMessages()
        {
            try {

                var data = messagesTableAdapter.GetCustomerMessages(AppData.userData.userId);

                messages.Clear();
                for (int i = 0; i < data.Rows.Count; i++) {

                    int messageId = int.Parse(data.Rows[i]["id"].ToString());
                    int vehicleId = int.Parse(data.Rows[i]["vehicle_id"].ToString());
                    int customerId = int.Parse(data.Rows[i]["customer_id"].ToString());
                    int employeeId = int.Parse(data.Rows[i]["employee_id"].ToString());
                    string messageBody = data.Rows[i]["message_body"].ToString();
                    string dateTime = data.Rows[i]["date_time"].ToString();
                    int isReplayed = int.Parse(data.Rows[i]["is_replayed"].ToString());


                    MessageModel messageModel = new MessageModel(messageId, vehicleId, customerId, employeeId, messageBody, dateTime, isReplayed);
                    messages.Add(messageModel);

                }
                return string.Empty;

            }
            catch (Exception e) { return e.Message; }
        }

        // Add new message
        public override string AddMessage(bool isReplayMessage, int customerId, string messageBody)
        {  
            int isReplayed = 0;

            if (isReplayMessage)
            {
                isReplayed = 1;
            }


            try {
                // The support employee id is 1027
                messagesTableAdapter.InsertQuery(0, AppVariables.supportEmployeeId, customerId, messageBody, isReplayed, DateTime.Now.ToString());

                return string.Empty;
            } catch (Exception e) { return e.Message; }
        }

        // Get support messages
        public override string GetSupportMessages()
        {

            try
            {
                var data = messagesTableAdapter.GetSupportMessages();

                messages.Clear();
                for (int i = 0; i < data.Rows.Count; i++)
                {

                    int messageId = int.Parse(data.Rows[i]["id"].ToString());
                    int vehicleId = int.Parse(data.Rows[i]["vehicle_id"].ToString());
                    int customerId = int.Parse(data.Rows[i]["customer_id"].ToString());
                    int employeeId = int.Parse(data.Rows[i]["employee_id"].ToString());
                    string messageBody = data.Rows[i]["message_body"].ToString();
                    string dateTime = data.Rows[i]["date_time"].ToString();
                    int isReplayed = int.Parse(data.Rows[i]["is_replayed"].ToString());


                    MessageModel messageModel = new MessageModel(messageId, vehicleId, customerId, employeeId, messageBody, dateTime, isReplayed);
                    messages.Add(messageModel);

                }
                return string.Empty;

            }
            catch (Exception e) { return e.Message; }
        }

        public override string UpdateReplayMessage(int messageId)
        {
            try
            {
                messagesTableAdapter.UpdateIsReplayedValue(messageId);

                return string.Empty;
            }catch(Exception e) { return e.Message; }
        }
    }
}

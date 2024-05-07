using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.messages.data.models
{
    public class MessageModel
    {
        public int id{ get; set; }
        public int vehicleId { get; set; }
        public int customerId { get; set; }
        public int employeeId { get; set; }
        public string messageBody { get; set; }
        public string dateTime { get; set; }
        public int isReplayed { get; set; }


        public MessageModel(int messageId, int vehicleId, int customerId, int employeeId, string messageBody, string dateTime, int isReplayed)
        {
            this.id = messageId;
            this.vehicleId = vehicleId;
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.messageBody = messageBody;
            this.dateTime = dateTime;
            this.isReplayed = isReplayed;
        }
    }

}

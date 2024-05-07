using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.home.data.models
{
    public class TransactionModel
    {
        public int transactionId { get; set; }
        public int customerId { get; set; }
        public int employeeId { get; set; }
        public int vehicleId { get; set; }
        public string status { get; set; }
        public string transactionType { get; set; }
        public string note { get; set; }
        public float amount { get; set; }
        public string paymentMethod { get; set; }
        public string date { get; set; }

        public TransactionModel()
        {
            // Default constructor
        }

        public TransactionModel(int transactionId, int customerId, int employeeId, int vehicleId, string status,
            string transactionType, string note, float amount, string paymentMethod, string date)
        {
            this.transactionId = transactionId;
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.vehicleId = vehicleId;
            this.status = status;
            this.transactionType = transactionType;
            this.note = note;
            this.amount = amount;
            this.paymentMethod = paymentMethod;
            this.date = date;
        }
    }

}

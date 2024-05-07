using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.invoices.data.models
{
    public class InvoiceModel
    {
        public int invoiceId { get; set; }
        public int customerId { get; set; }
        public int employeeId { get; set; }
        public string invoiceDate { get; set; }
        public float totalAmount { get; set; }
        public string paymentMethod { get; set; }
        public string paymentDate { get; set; }
        public float taxes { get; set; }
        public float discounts { get; set; }
        public string notes { get; set; }

        public InvoiceModel(int invoiceId, int customerId, int employeeId, string invoiceDate,
                            float totalAmount, string paymentMethod, string paymentDate,
                            float taxes, float discounts, string notes) 
        {
            this.invoiceId = invoiceId;
            this.customerId = customerId;
            this.employeeId = employeeId;
            this.invoiceDate = invoiceDate;
            this.totalAmount = totalAmount;
            this.paymentMethod = paymentMethod;
            this.paymentDate = paymentDate;
            this.taxes = taxes;
            this.discounts = discounts;
            this.notes = notes;
        }
    }

}

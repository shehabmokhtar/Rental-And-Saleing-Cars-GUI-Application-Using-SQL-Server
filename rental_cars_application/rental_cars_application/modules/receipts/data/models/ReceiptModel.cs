using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.receipts.data.models
{
    public class ReceiptModel
    {
        public int receiptId { get; set; }
        public int invoiceId { get; set; }
        public string date { get; set; }
        public string notes { get; set; }

        public ReceiptModel(int receiptId, int invoiceId, string date, string notes)
        {
            this.receiptId = receiptId;
            this.invoiceId = invoiceId;
            this.date = date;
            this.notes = notes;
        }
    }

}

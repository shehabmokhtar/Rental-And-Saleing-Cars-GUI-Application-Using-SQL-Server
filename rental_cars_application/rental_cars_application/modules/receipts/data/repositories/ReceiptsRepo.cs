using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.receipts.data.repositories
{
    internal abstract class ReceiptsRepo
    {
        public abstract string GetCustomerReceipts();
        public abstract string AddNewReceipt(int invoiceId, string note);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.invoices.data.repositories
{
    internal abstract class InvoicesRepo
    {
        // Get customer invoices
        public abstract string GetCustomerInvoices();
        // Add a new invoice after the user purchase
        public abstract string AddNewInvoice(int employeeId, float totalAmount, float taxes, float discount, string note);
        // Get Invoice id by vehicle id
        public abstract int GetInvoiceId();

    }
}

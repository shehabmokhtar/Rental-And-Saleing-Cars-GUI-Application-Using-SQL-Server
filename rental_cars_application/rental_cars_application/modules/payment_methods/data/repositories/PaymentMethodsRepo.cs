using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.payment_methods.data.repositories
{
    internal abstract class PaymentMethodsRepo
    {
        public abstract string AddCustomerPaymentMethod(string paymentmethod);
    }
}

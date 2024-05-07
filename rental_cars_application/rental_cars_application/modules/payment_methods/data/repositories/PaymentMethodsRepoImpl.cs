using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.payment_methods.data.repositories
{
    internal class PaymentMethodsRepoImpl : PaymentMethodsRepo
    {
        usersTableAdapter usersTableAdapter = new usersTableAdapter();

        public override string AddCustomerPaymentMethod(string paymentmethod)
        {
            try { 
            usersTableAdapter.UpdatePaymentMethodById(paymentmethod,AppData.userData.userId);
                return string.Empty;
            }catch(Exception ex) { return ex.Message; }
        }
    }
}

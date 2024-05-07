 using rental_cars_application.core.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.authantication.data.repository
{
    abstract class AuthanticationRepo
    {

        public abstract string SignUp(string first_name, string last_name, string email,
                                string password, string phone_number, string birthday,
                                string address, string current_location, string payment_method,
                                string identification_card_number, string role);


        public abstract string SignIn(string phoneNumber, string password);
    }
}

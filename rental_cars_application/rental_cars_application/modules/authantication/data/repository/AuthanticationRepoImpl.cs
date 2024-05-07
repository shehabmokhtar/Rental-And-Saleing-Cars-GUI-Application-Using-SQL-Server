using rental_cars_application.core.database;
using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using rental_cars_application.modules.authantication.data.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace rental_cars_application.modules.authantication.data.repository
{
    internal class AuthanticationRepoImpl : AuthanticationRepo
    {
        public RentalCarsDataset rentalCarsDatabase = new RentalCarsDataset();
        public usersTableAdapter usersTableAdapter = new usersTableAdapter();
        AuthanticationValidationFunctions authFunctions = new AuthanticationValidationFunctions();

        public override string SignUp(string first_name, string last_name, string email, string phone_number,string password,  string birthday, string address, string current_location, string payment_method, string identification_card_number, string role)
         {
            string message;

            message = IsPhoneNumberAlreadyRegistered(phone_number);
            
            // The phone number didn't registere before 
            if(message == string.Empty)
            {
                // Check the password, email, birthday formats
                message = authFunctions.RegistrationValidation(email, password, birthday);

                if (message == string.Empty)
                {
                    try
                    {
                        usersTableAdapter.InsertQuery(first_name, last_name, email, phone_number, password, birthday, address, current_location, payment_method, identification_card_number, role);

                        message = string.Empty;
                        return message;
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        return message;
                    }
                }
                else
                {
                    return message;
                }
            }
            // The phone number is registered before
            else {
                return message;
            }

      
        }

        public override string SignIn(string phoneNumber, string password)
        {
            // Get all users
           string m =  GetUsersDataFromDB.GetUsers();

            if(m == string.Empty)
            {
                return checkUserIsInDBOrNot(phoneNumber,password);

            }
            return "Error";

            
        }

        private string IsPhoneNumberAlreadyRegistered(string phoneNumber)
        {
            GetUsersDataFromDB.GetUsers();

            foreach(UserModel user in GetUsersDataFromDB.users)
            {
                if(user.phoneNumber == phoneNumber)
                {
                    return "Phone number is already registered, Change the phone number";
                }
            }
            return string.Empty;    
        }


        private string checkUserIsInDBOrNot(string phoneNumber, string password)
        {
            GetUsersDataFromDB.GetUsers();

            foreach (UserModel user in GetUsersDataFromDB.users)
            {
                if(user.phoneNumber == phoneNumber)
                {
                    if(user.password == password)
                    {
                        AppData.userData = user;
                        return string.Empty;
                    }
                    return "Password is not correct";
                }
            }
            return "User not found, Check your phone number";
        }
    }
}

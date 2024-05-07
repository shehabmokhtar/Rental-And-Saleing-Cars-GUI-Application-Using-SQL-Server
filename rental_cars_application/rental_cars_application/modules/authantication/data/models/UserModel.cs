using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.authantication.data.models
{
    public class UserModel
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string current_location { get; set; }
        public string paymentMethod { get; set; }
        public string identificationCardNumber { get; set; }
        public string role { get; set; }

        // Constructor with parameters
        public UserModel(int user_id, string first_name, string last_name, string email, string password,
                    string phone_number, string birthday, string address, string current_location,
                    string payment_method, string identification_card_number, string role)
        {
            this.userId = user_id;
            this.firstName = first_name;
            this.lastName = last_name;
            this.email = email;
            this.password = password;
            this.phoneNumber = phone_number;
            this.birthday = birthday;
            this.address = address;
            this.current_location = current_location;
            this.paymentMethod = payment_method;
            this.identificationCardNumber = identification_card_number;
            this.role = role;
        }

        // Display method to show user attributes
        public void Display()
        {
            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"last_name: {lastName}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Birthday: {birthday}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Current Location: {current_location}");
            Console.WriteLine($"Payment Method: {paymentMethod}");
            Console.WriteLine($"ID Card Number: {identificationCardNumber}");
            Console.WriteLine($"Role: {role}");
        }
    }

}

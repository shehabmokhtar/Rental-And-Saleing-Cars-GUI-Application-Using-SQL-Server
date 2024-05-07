using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace rental_cars_application.core.utilities
{
    public class AuthanticationValidationFunctions
    {
        // This function make validation for email, password, and birthday
        public string RegistrationValidation(string email,string password, string birthday)
        {
            string message = CheckEmailFormat(email);

            // Check email format
                if (message == string.Empty)
            {

                // Check password
                message = CheckPassword(password);
                if (message == string.Empty) { 
                
                
                // Check birthday
                message = CheckBirthdayFormat(birthday);
                if(message == string.Empty) { 
                    
                    return string.Empty;
                    }
                    else
                    {
                        return message;
                    }
                
                } else
                {
                    return message;
                }
            }
            else
            {
                return message;
            }
        }

        // Check email format
        private  string CheckEmailFormat(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            if (Regex.IsMatch(email, pattern))
            {
                return string.Empty;
            }
            else
            {
                return "The email format is wrong. It should be in the format: example@example.com";
            }
        }


        // Check password
        private  string CheckPassword(string password)
        {
            // Minimum and maximum password length
            int minLength = 8;
            int maxLength = 20;

            // Regular expression pattern for checking alphanumeric and special characters
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^a-zA-Z\d\s]).{" + minLength + "," + maxLength + "}$";

            // Check if the password meets the criteria
            if (password.Length >= minLength && password.Length <= maxLength && Regex.IsMatch(password, pattern))
            {
                return string.Empty;
            }
            else
            {
                return "The password should be between " + minLength + " and " + maxLength + " characters long and contain at least one letter, one digit, and one special character.";
            }
        }

        // Check the birthday format
        private string CheckBirthdayFormat(string birthday)
        {
            try
            {
                // Parse the input string into a DateTime object using the specified format
                DateTime parsedDate = DateTime.ParseExact(birthday, "MM.dd.yyyy", null);

                // Check if the parsed date is valid (e.g., not a future date)
                if (parsedDate <= DateTime.Now)
                {
                    return string.Empty; // Return empty string if the format and date are valid
                }
                else
                {
                    return "Birthday date cannot be in the future.";
                }
            }
            catch (FormatException)
            {
                return "Invalid birthday format. Please use the format MM.dd.yyyy (e.g., 11.20.2002).";
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }
    }
}

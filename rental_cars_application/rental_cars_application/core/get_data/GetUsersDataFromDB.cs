using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rental_cars_application.modules.authantication.data.models;
using rental_cars_application.core.get_data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;
using System.Net;

namespace rental_cars_application.core.utilities
{
    internal class GetUsersDataFromDB : GetData
    {
       public static usersTableAdapter usersTable = new usersTableAdapter();
        public static List<UserModel> users = new List<UserModel>();


        // Get users from database
        public static string GetUsers()
        {
          var userData  = usersTable.GetData();

            try {

                users.Clear();
                for (int i = 0; i < userData.Rows.Count; i++)
                {

                    // Assign textboxs to variables
                    int user_id = int.Parse(userData.Rows[i]["user_id"].ToString());
                    string first_name = userData.Rows[i]["first_name"] as string;
                    string last_name = userData.Rows[i]["last_name"] as string;
                    string email = userData.Rows[i]["email"] as string; ;
                    string password = userData.Rows[i]["password"] as string;
                    string phone_number = userData.Rows[i]["phone_number"] as string;
                    string birthday = userData.Rows[i]["birthday"] as string;
                    string address = userData.Rows[i]["address"] as string;
                    string current_location = userData.Rows[i]["current_location"] as string;
                    string payment_method = userData.Rows[i]["payment_methods"] as string;
                    string identification_card_number = userData.Rows[i]["identification_card_number"] as string;
                    string role = userData.Rows[i]["role"] as string;


                    // Create a new user model object
                    UserModel userModel = new UserModel(user_id, first_name, last_name, email, password, phone_number, birthday, address, current_location, payment_method, identification_card_number, role);
   
                    // Add each user model to the users list
                     users.Add(userModel);


                }

                return string.Empty;
            }
            catch(Exception ex) { 
            
            return ex.Message;    
            }
        }
   
        // Get user data
    public static string GetUserData(string phoneNumber) {
            
            // Get all users
            GetUsers();

            // Get User Data
            foreach(UserModel userModel in users) {
            
            if(userModel.phoneNumber == phoneNumber)
                {

                    AppData.userData = userModel;
                    users.Clear();
                    return string.Empty;
                }
            }


            users.Clear();
                    return "Not found";
        }

        // Get User by id
   public static Tuple<string,UserModel> GetUserById(int userId)
        {
            UserModel userModel = new UserModel(0,"", "","","","","", "","", "","", "");

            try
            {
                var userData = usersTable.GetUser(userId);

                // Assign textboxs to variables
                int user_id = int.Parse(userData.Rows[0]["user_id"].ToString());
                string first_name = userData.Rows[0]["first_name"] as string;
                string last_name = userData.Rows[0]["last_name"] as string;
                string email = userData.Rows[0]["email"] as string; ;
                string password = userData.Rows[0]["password"] as string;
                string phone_number = userData.Rows[0]["phone_number"] as string;
                string birthday = userData.Rows[0]["birthday"] as string;
                string address = userData.Rows[0]["address"] as string;
                string current_location = userData.Rows[0]["current_location"] as string;
                string payment_method = userData.Rows[0]["payment_methods"] as string;
                string identification_card_number = userData.Rows[0]["identification_card_number"] as string;
                string role = userData.Rows[0]["role"] as string;


                // Create a new user model object
                 userModel = new UserModel(user_id, first_name, last_name, email, password, phone_number, birthday, address, current_location, payment_method, identification_card_number, role);

                return Tuple.Create(string.Empty, userModel);

            }
            catch(Exception ex) {
                return Tuple.Create(ex.Message,userModel);
            }


        }
    
    }
}

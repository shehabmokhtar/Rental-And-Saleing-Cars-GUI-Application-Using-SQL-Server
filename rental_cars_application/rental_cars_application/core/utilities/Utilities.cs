using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using rental_cars_application.modules.home.data.models;
using rental_cars_application.modules.home.data.repositories.employe_repo;
using rental_cars_application.modules.home.presentation.items;
using rental_cars_application.modules.home.presentation.forms;



namespace rental_cars_application.utilities
{
    internal class Utilities
    {
        public static void NavigateToNewForm(Form current,Form next) {
            
            if(current != null && next != null) {
           
                current.Hide();
                next.Show();    
            }
            else
            {
                MessageBox.Show("Error");   
            }
        }

        public static string CheckTextBoxIsNullOrEmpty(List<string> texts, List<string> errorMessages)
        {


            for (int i = 0; i < texts.Count(); i++)
            {

                if (string.IsNullOrEmpty(texts[i]))
                {
                    return errorMessages[i];
                }
            }
            return string.Empty;
        }

        // Load an image from cleint
        public static Image LoadImageFromUrl(string imageUrl)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] imageData = webClient.DownloadData(imageUrl);

                // Convert the downloaded byte array to an Image object
                Image image;
                using (var ms = new System.IO.MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }

                return image;
            }
            catch (Exception ex)
            {
                // Handle exceptions or return null if image cannot be loaded
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }


        // Generate vehicles list of items
        public static bool GenerateVehiclesItemsList(bool isEmployeeVehicles, dynamic flowControls)
        {
            VehiclesRepoImpl vehiclesRepoImpl = new VehiclesRepoImpl();

            List<VehicleModel> vehicles = new List<VehicleModel>();
            bool success = true;

            // Get the employee or the customer data
            if (isEmployeeVehicles)
            {
                string result = vehiclesRepoImpl.GetEmployeeVehicles();
                if (result == string.Empty)
                {
                    vehicles = VehiclesRepoImpl.employeeVehicles;

                }
                else
                {
                    CheckAndDisplayResult(result);
                    success = false;
                    return success;
                }
            }
            else
            {
                string result = vehiclesRepoImpl.GetCustomerVehicles();
                if (result == string.Empty)
                {
                     vehicles  = VehiclesRepoImpl.customerVehicles;
                }
                else
                {
                    CheckAndDisplayResult(result);
                    success = false;
                    return success;
                }
            }

            foreach (VehicleModel vehicle in vehicles)
            {
                VehicleItem vehicleItem = new VehicleItem(vehicle);
         flowControls.Add(vehicleItem);
            }

            return success;

        }

        // Check result
        public static void CheckAndDisplayResult(string result)
        {
            if (result != string.Empty)
            {
                MessageBox.Show(result);
            }
        }

        // Add new vehicle button


        // Get price label
        public static string GetPriceLabel(float salePrice)
        {
            if (salePrice != 0)
            {
                return "Selling price:";
            }
            else
            {
                return "Daily renting price:";
            }
        }

        // Get saling or renting price
        public static string GetSellingOrRentingPrice(float salePrice,float dailyRentPrice)
        {
            float price = 0;

            if (salePrice == 0)
            {
                price = dailyRentPrice;
            }
            else
            {
                price = salePrice;
            }

            return price.ToString();
        }


        // Is the vehicle available or not
        public static void IsTheVehicleAvailableOrNot(Label label,int available)
        {
            if (available == 1)
            {
                label.BackColor = Color.DarkGreen;
                label.Text = "Available";
            }
            else
            {
                label.BackColor = Color.DarkRed;
                label.Text = "Un Available";
            }
        }


    }
}

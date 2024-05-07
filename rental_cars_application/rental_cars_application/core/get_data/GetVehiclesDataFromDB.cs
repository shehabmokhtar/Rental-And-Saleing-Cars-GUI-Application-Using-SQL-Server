using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.modules.authantication.data.models;
using rental_cars_application.modules.home.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application.core.get_data
{
    internal class GetVehiclesDataFromDB : GetData
    {
       public static vehiclesTableAdapter vehiclesTable = new vehiclesTableAdapter();
        public static List<VehicleModel> vehicles = new List<VehicleModel>();   

        // Get vehiles from db
        public static string GetVehicles()
        {
            var vehiclesData = vehiclesTable.GetData();
            

            try
            {

                vehicles.Clear();
                for (int i = 0; i < vehiclesData.Rows.Count; i++)
                {

                    // Assign textboxs to variables
                    int vehicleId = int.Parse(vehiclesData.Rows[i]["vehicle_id"].ToString());
                    int employeeId = int.Parse(vehiclesData.Rows[i]["employee_id"].ToString());
                    int customerId = int.Parse(vehiclesData.Rows[i]["customer_id"].ToString());
                    string imageUrl = vehiclesData.Rows[i]["image_url"] as string;
                    string manufacturer = vehiclesData.Rows[i]["manufacturer"] as string;
                    string model = vehiclesData.Rows[i]["model"] as string;
                    string year = vehiclesData.Rows[i]["year"] as string;
                    string color = vehiclesData.Rows[i]["color"] as string;
                    string droveKilometers = vehiclesData.Rows[i]["drove_kilometers"] as string;
                    string transmission = vehiclesData.Rows[i]["transmission"] as string;
                    string engineCc = vehiclesData.Rows[i]["engine_cc"] as string;
                    float salePrice = float.Parse(vehiclesData.Rows[i]["sale_price"].ToString());
                    float dailyRentalPrice = float.Parse(vehiclesData.Rows[i]["daily_rental_price"].ToString());
                    // 1 is available 0 is not available
                    int available = int.Parse(vehiclesData.Rows[i]["available"].ToString());
                    string currentLocation = vehiclesData.Rows[i]["current_location"] as string;

                    // Create a new vechile model object
                    VehicleModel vehicleModel = new VehicleModel(vehicleId,employeeId,customerId, imageUrl, manufacturer, model,year, color,droveKilometers,transmission,engineCc,salePrice,dailyRentalPrice, available,currentLocation);           
                    // Add each user model to the users list
                    vehicles.Add(vehicleModel);

                }
                        
                return string.Empty;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}

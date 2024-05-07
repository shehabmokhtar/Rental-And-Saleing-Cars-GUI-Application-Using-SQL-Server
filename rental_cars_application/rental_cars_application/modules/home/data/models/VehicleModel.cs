using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.home.data.models
{
    public class VehicleModel
    {
        public int id { get; set; } // Primary key
        public int employeeId { get; set; }
        public int customerId { get; set; }
        public string imageUrl{ get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string droveKilometers { get; set; }
        public string transmission { get; set; }
        public string engineCc { get; set; }
        public float salePrice { get; set; }
        public float dailyRentalPrice { get; set; }
        public int available { get; set; }
        public string currentLocation { get; set; }

        public VehicleModel(int vehicleId, int employeeId, int customerId,string imageUrl, string manufacturer, string model,
            string year, string color, string droveKilometers, string transmission, string engineCc,
            float salePrice, float dayRentPrice, int available, string currentLocation)
        {
            this.id = vehicleId;
            this.employeeId = employeeId;
            this.customerId = customerId;
            this.imageUrl = imageUrl;
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
            this.color = color;
            this.droveKilometers = droveKilometers;
            this.transmission = transmission;
            this.engineCc = engineCc;
            this.salePrice = salePrice;
            this.dailyRentalPrice = dayRentPrice;
            this.available = available;
            this.currentLocation = currentLocation;
        }

        public void Display()
        {
            Console.WriteLine($"Vehicle ID: {this.id}");
            Console.WriteLine($"Employee ID: {this.employeeId}");
            Console.WriteLine($"Customer ID: {this.customerId}");
            Console.WriteLine($"Image URL: {this.imageUrl}");
            Console.WriteLine($"Manufacturer: {this.manufacturer}");
            Console.WriteLine($"Model: {this.model}");
            Console.WriteLine($"Year: {this.year}");
            Console.WriteLine($"Color: {this.color}");
            Console.WriteLine($"Drove Kilometers: {this.droveKilometers}");
            Console.WriteLine($"Transmission: {this.transmission}");
            Console.WriteLine($"Engine CC: {this.engineCc}");
            Console.WriteLine($"Sale Price: {this.salePrice}");
            Console.WriteLine($"Day Rent Price: {this.dailyRentalPrice}");
            Console.WriteLine($"Available: {this.available}");
            Console.WriteLine($"Current Location: {this.currentLocation}");
        }
    }

}

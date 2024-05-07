using rental_cars_application.modules.home.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.home.data.repositories.employe_repo
{
    internal abstract class VehiclesRepo
    {
        public abstract String GetEmployeeVehicles();
        public abstract String GetCustomerVehicles();
        public abstract String AddNewVehicle(VehicleModel vehicle);
        public abstract String UpdateVehicleById(VehicleModel vehicle);
        public abstract String DeleteVehicleById(int vehicleId);
        public abstract String UpdateAvailability(int vehicleId);



    }
}

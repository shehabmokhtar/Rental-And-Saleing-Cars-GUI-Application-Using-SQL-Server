using rental_cars_application.core.database.RentalCarsDatasetTableAdapters;
using rental_cars_application.core.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.core.core_repo
{
    internal class CoreRepoImpl : CoreRepo
    {
        private usersTableAdapter usersTableAdapter  = new usersTableAdapter();
        private vehiclesTableAdapter vehiclesTableAdapter = new vehiclesTableAdapter();

        public override string UpdateCustomerCurrentLocation(string currentLocation)
        {
            try {
                usersTableAdapter.UpdateCurrentLocation(currentLocation,AppData.userData.userId);
                return string.Empty;

            }catch(Exception ex) {
                return ex.Message;
            }
        }

    }
}

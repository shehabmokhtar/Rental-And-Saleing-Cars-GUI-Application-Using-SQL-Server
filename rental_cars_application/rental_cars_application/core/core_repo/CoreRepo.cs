using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.core
{
    internal abstract class CoreRepo
    {
        public abstract string UpdateCustomerCurrentLocation(string currentLocation);
    }
}

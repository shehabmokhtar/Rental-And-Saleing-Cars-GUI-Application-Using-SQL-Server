using rental_cars_application.core.utilities;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.core.services
{
  

    public class LocationService
    {
       
        private static GeoCoordinateWatcher watcher;
        public LocationService()
        {
            // Initialize the GeoCoordinateWatcher
            watcher = new GeoCoordinateWatcher();
        }

        public static void GetCurrentLocation()    
        {
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000)); // Start listening for location changes

            if (watcher.Status == GeoPositionStatus.Ready)
            {
                GeoCoordinate coordinate = watcher.Position.Location;
                double latitude = coordinate.Latitude;
                double longitude = coordinate.Longitude;

                AppData.userLatitude = latitude.ToString();
                AppData.userLongtude = longitude.ToString();

            }
            else
            {
                Console.WriteLine("Error when getting location");
            }
        }

        public void StopLocationTracking()
        {
            watcher.Stop(); // Stop listening for location changes
        }
    }

}

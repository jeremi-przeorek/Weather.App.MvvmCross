using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Weather.App.MvvmCross.Core.Services
{
    public class LocationService : ILocationService
    {
        public LocationService()
        {
        }

        public async Task<Location> GetCurrentLocationAsync()
        {
            var location = new Location();

            try
            {
                location = await Geolocation.GetLocationAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return location;
        }
    }
}

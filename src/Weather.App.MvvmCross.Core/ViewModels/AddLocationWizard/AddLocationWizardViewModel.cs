using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using System;
using Weather.App.MvvmCross.Core.Data;
using Weather.App.MvvmCross.Core.Services;
using MvvmCross.Plugin.Location;
using Weather.App.MvvmCross.Core.Models;
using Acr.UserDialogs;
using MvvmCross;

namespace Weather.App.MvvmCross.Core.ViewModels.AddLocationWizard
{
    public class AddLocationWizardViewModel : BaseViewModel
    {
        private WeatherLocationRepository _weatherLocationRepository = new WeatherLocationRepository();
        private WeatherForecastService _weatherForecastService = new WeatherForecastService();

        public INC<bool> IsRefreshing = new NC<bool>();

        private readonly IUserDialogs _userDialogs;
        private readonly ILocationService _locationService;

        public AddLocationWizardViewModel(
            IUserDialogs userDialogs,
            ILocationService locationService)
        {
            _userDialogs = userDialogs;
            _locationService = locationService;
        }


        public async void AddLocationByMyLocation()
        {   
            IsRefreshing.Value = true;

            var location = await _locationService.GetCurrentLocationAsync();

            if (location != null)
            {
                var weatherLocation =
                    await _weatherForecastService.GetWeatherLocationByLatLonAsync(location.Latitude, location.Longitude);

                _weatherLocationRepository.Add(new WeatherLocation
                {
                    City = weatherLocation.City,
                    CountryCode = weatherLocation.CountryCode,
                });

                await _userDialogs.AlertAsync(string.Format("Properly added city: {0}", weatherLocation.City), "Success", "Ok");
                IsRefreshing.Value = false;
            }
        }

        public async void AddLocationByList()
        {

            //await _pageService.PushAsync(new AddLocationFromListWizard());
        }
    }
}

using MvvmCross.Plugin.FieldBinding;
using Weather.App.MvvmCross.Core.Data;
using Weather.App.MvvmCross.Core.Services;
using Weather.App.MvvmCross.Core.Models;
using Acr.UserDialogs;
using MvvmCross.Navigation;
using Weather.App.MvvmCross.Core.ViewModels.AddLocationFromListWizard;

namespace Weather.App.MvvmCross.Core.ViewModels.AddLocationWizard
{
    public class AddLocationWizardViewModel : BaseViewModel
    {
        public INC<bool> IsRefreshing = new NC<bool>();

        private readonly IUserDialogs _userDialogs;
        private readonly ILocationService _locationService;
        private readonly IMvxNavigationService _navigationService;
        private readonly IWeatherLocationRepository _weatherLocationRepository;
        private readonly IWeatherForecastService _weatherForecastService;

        public AddLocationWizardViewModel(
            IUserDialogs userDialogs,
            ILocationService locationService,
            IMvxNavigationService navigationService,
            IWeatherLocationRepository weatherLocationRepository,
            IWeatherForecastService weatherForecastService)
        {
            _userDialogs = userDialogs;
            _locationService = locationService;
            _navigationService = navigationService;
            _weatherLocationRepository = weatherLocationRepository;
            _weatherForecastService = weatherForecastService;
        }

        public async void AddLocationByMyLocationAsync()
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

        public async void AddLocationByListAsync()
        {
            await _navigationService.Navigate<AddLocationFromListWizardViewModel>();
        }
    }
}

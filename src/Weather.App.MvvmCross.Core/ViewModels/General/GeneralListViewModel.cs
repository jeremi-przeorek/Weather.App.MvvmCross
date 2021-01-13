using System.Collections.Generic;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using Weather.App.MvvmCross.Core.Data;
using Weather.App.MvvmCross.Core.Models;
using Weather.App.MvvmCross.Core.ViewModels.AddLocationWizard;
using Weather.App.MvvmCross.Core.ViewModels.WeatherPresentation;

namespace Weather.App.MvvmCross.Core.ViewModels.General
{
    public class GeneralListViewModel : BaseViewModel
    {
        private readonly IWeatherLocationRepository _weatherLocationRepository;
        private readonly IMvxNavigationService _navigationService;

        public INC<List<WeatherLocation>> WeatherLocations = new NC<List<WeatherLocation>>();

        public INC<bool> IsRefreshing = new NC<bool>();
        
        public GeneralListViewModel(
            IMvxNavigationService navigationService,
            IWeatherLocationRepository weatherLocationRepository)
        {
            _navigationService = navigationService;
            _weatherLocationRepository = weatherLocationRepository;
        }

        public async void ShowAddLocationWizardAsync()
        {
            await _navigationService.Navigate<AddLocationWizardViewModel>();
        }

        public void UpdateWeatherLocationsList()
        {
            WeatherLocations.Value = new List<WeatherLocation>(_weatherLocationRepository.GetAll());
            IsRefreshing.Value = false;
        }

        public async void ShowWeatherPresentationPageAsync(WeatherLocation location)
        {
            await _navigationService.Navigate<WeatherPresentationViewModel, WeatherLocation>(location);
        }

        public void DeleteWeatherLocationEntity()
        {
            var a = 12;
            //_weatherLocationRepository.Remove(location);
            UpdateWeatherLocationsList();
        }

        public override void ViewAppearing()
        {
            WeatherLocations.Value = new List<WeatherLocation>(_weatherLocationRepository.GetAll());

            base.ViewAppearing();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;
using Weather.App.MvvmCross.Core.Data;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.ViewModels.AddLocationFromListWizard
{
    public class AddLocationFromListWizardViewModel : MvxViewModel
    {
        private List<WeatherLocation> _locationsUnfiltered;
        public INC<List<WeatherLocation>> Locations = new NC<List<WeatherLocation>>();

        private string _searchBarText;
        public string SearchBarText
        {
            get => _searchBarText;
            set
            {
                _searchBarText = value;
                TextChangedInSearchBar(value);
            }
        }

        private readonly IWeatherLocationRepository _weatherLocationRepository;
        private readonly IUserDialogs _userDialogs;
        private readonly IResourcesLoader _resourcesLoader;

        public AddLocationFromListWizardViewModel(
            IUserDialogs userDialogs,
            IResourcesLoader resourcesLoader,
            IWeatherLocationRepository weatherLocationRepository)
        {
            _userDialogs = userDialogs;
            _resourcesLoader = resourcesLoader;
            _weatherLocationRepository = weatherLocationRepository;
        }

        public async Task LoadLocationsAsync()
        {
            Locations.Value = new List<WeatherLocation>(await _resourcesLoader.LoadWeatherLocationsAsync()); //uzyc ioc
            _locationsUnfiltered = Locations.Value;
        }

        private void TextChangedInSearchBar(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Locations.Value = new List<WeatherLocation>(
                    _locationsUnfiltered.Where(x => x.City.StartsWith(input, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                Locations.Value = _locationsUnfiltered;
            }
        }

        public async Task AddLocationAsync(WeatherLocation location)
        {
            _weatherLocationRepository.Add(new WeatherLocation
            {
                City = location.City,
                CountryCode = location.CountryCode,
            });

            await _userDialogs.AlertAsync(string.Format("Properly added city: {0}", location.City), "Success",  "Ok");
        }

        public override async void ViewAppearing()
        {
            await LoadLocationsAsync();

            base.ViewAppearing();
        }
    }
}

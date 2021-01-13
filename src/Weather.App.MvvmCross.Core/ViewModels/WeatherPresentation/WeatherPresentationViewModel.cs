using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Navigation;
using MvvmCross.Plugin.FieldBinding;
using MvvmCross.ViewModels;
using Weather.App.Models;
using Weather.App.MvvmCross.Core.Models;
using Weather.App.MvvmCross.Core.Services;

namespace Weather.App.MvvmCross.Core.ViewModels.WeatherPresentation
{
    public class WeatherPresentationViewModel : BaseViewModel<WeatherLocation>
    {
        private WeatherForecastService _weatherForecastService = new WeatherForecastService(); // dodac interfejs
        private WeatherLocation _location;
        private readonly IUserDialogs _userDialogs;
        public INC<bool> IsDataLoading = new NC<bool>();

        public INC<List<DailyForecastDto>> DailyForecastDtos = new NC<List<DailyForecastDto>>();

        public INC<int> SelectedDay = new NC<int>();

        public INC<DailyForecastDto> SelectedDayForecast = new NC<DailyForecastDto>();

        public INC<string> Title = new NC<string>();

        public WeatherPresentationViewModel(IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs ?? throw new System.ArgumentNullException(nameof(userDialogs));
        }

        private async Task GetWeatherDataAsync()
        {
            IsDataLoading.Value = true;
            var dailyForecast16DaysDto = await _weatherForecastService.GetDailyForecastFor16DaysAsync(_location);
            IsDataLoading.Value = false;

            if (dailyForecast16DaysDto == null)
            {
                await _userDialogs.AlertAsync("There was problem with getting your data :(", "Error", "Ok");
                return;
            }

            DailyForecastDtos.Value = new List<DailyForecastDto>(dailyForecast16DaysDto.Data);
        }

        private void ChangeSelectedDay(int selectedDayIndex)
        {
            SelectedDayForecast.Value = DailyForecastDtos.Value[selectedDayIndex];
        }

        public override async void ViewAppearing()
        {
            //Title.Value = string.Format("Weather forecast for {0}", _location.City);

            DailyForecastDtos.Value = new List<DailyForecastDto>();

            await GetWeatherDataAsync();

            base.ViewAppearing();
        }

        public override void Prepare(WeatherLocation parameter)
        {
            _location = parameter;
        }
    }
}

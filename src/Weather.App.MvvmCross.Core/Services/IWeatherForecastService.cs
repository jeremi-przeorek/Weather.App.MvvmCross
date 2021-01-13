using System.Threading.Tasks;
using Weather.App.Models;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherLocation> GetWeatherLocationByLatLonAsync(double latitude, double longitude);

        Task<DailyForecast16DaysDto> GetDailyForecastFor16DaysAsync(WeatherLocation location);
    }
}

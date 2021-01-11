using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.App.Models;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Services
{
    class WeatherForecastService
    {
        private const string ApiUrl = "https://api.weatherbit.io/v2.0";
        private const string ApiKey = "d2053f9f82d6422ba965b36c2acda96f";

        public async Task<WeatherLocation> GetWeatherLocationByLatLonAsync(double latitude, double longitude)
        {
            var url = ApiUrl
                .AppendPathSegments("forecast", "daily")
                .SetQueryParams(new
                {
                    key = ApiKey,
                    lat = latitude,
                    lon = longitude
                });

            var weather = await url.GetJsonAsync<DailyForecast16DaysDto>();

            return new WeatherLocation
            {
                City = weather.CityName,
                CountryCode = weather.CountryCode,
            };
        }

        public async Task<DailyForecast16DaysDto> GetDailyForecastFor16DaysAsync(WeatherLocation location)
        {
            // use result class

            try
            {
                var url = ApiUrl
                    .AppendPathSegments("forecast", "daily")
                    .SetQueryParams(new
                    {
                        key = ApiKey,
                        city = location.City,
                        country = location.CountryCode
                    });

                return await url.GetJsonAsync<DailyForecast16DaysDto>();
            }
            catch (FlurlHttpException)
            {
                return null;
            }
        }
    }
}

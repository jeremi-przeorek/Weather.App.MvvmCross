using MvvmCross;
using System.Collections.Generic;
using System.Linq;
using Weather.App.MvvmCross.Core.Models;
using Weather.App.MvvmCross.Core.Services;

namespace Weather.App.MvvmCross.Core.Data
{
    public class WeatherLocationRepository : IWeatherLocationRepository
    {
        public void Add(WeatherLocation location)
        {
            using (var weatherlocationContext = new WeatherLocationContext())
            {
                weatherlocationContext.WeatherLocations.Add(location);
                weatherlocationContext.SaveChanges();
            }
        }

        public IEnumerable<WeatherLocation> GetAll()
        {
            using (var weatherlocationContext = new WeatherLocationContext())
            {
                return weatherlocationContext.WeatherLocations.ToList();
            }
        }

        public void Remove(WeatherLocation location)
        {
            using (var weatherlocationContext = new WeatherLocationContext())
            {
                weatherlocationContext.WeatherLocations.Remove(location);
                weatherlocationContext.SaveChanges();
            }
        }
    }
}

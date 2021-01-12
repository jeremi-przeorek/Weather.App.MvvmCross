using System.Collections.Generic;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Data
{
    public interface IWeatherLocationRepository
    {
        IEnumerable<WeatherLocation> GetAll();
        void Add(WeatherLocation location);
        void Remove(WeatherLocation location);
    }
}

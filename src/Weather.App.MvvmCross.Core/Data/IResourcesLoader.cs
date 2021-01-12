using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Data
{
    public interface IResourcesLoader
    {
        Task<List<WeatherLocation>> LoadWeatherLocationsAsync();
    }
}

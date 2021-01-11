using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Weather.App.Models;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Data
{
    public static class ResourcesLoader
    {
        private static List<WeatherLocation> _weatherLocations;
        public static async Task<List<WeatherLocation>> LoadWeatherLocationsAsync()
        {
            if (_weatherLocations != null)
            {
                return _weatherLocations;
            }

            var assembly = typeof(ResourcesLoader).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Weather.App.Resources.cities_20000.json");

            using (var reader = new StreamReader(stream))
            {
                _weatherLocations = await Task.Run(() => JsonConvert.DeserializeObject<List<WeatherLocation>>(reader.ReadToEnd()));
                return _weatherLocations;
            }
        }
    }
}

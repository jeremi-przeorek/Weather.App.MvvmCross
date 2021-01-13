using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Data
{
    public class ResourcesLoader : IResourcesLoader
    {
        private List<WeatherLocation> _weatherLocations;
        public async Task<List<WeatherLocation>> LoadWeatherLocationsAsync()
        {
            if (_weatherLocations != null)
            {
                return _weatherLocations;
            }

            var assembly = typeof(ResourcesLoader).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Weather.App.MvvmCross.Core.Resources.cities_20000.json");

            using (var reader = new StreamReader(stream))
            {
                _weatherLocations = await Task.Run(() => JsonConvert.DeserializeObject<List<WeatherLocation>>(reader.ReadToEnd()));
                return _weatherLocations;
            }
        }
    }
}

using Newtonsoft.Json;

namespace Weather.App.MvvmCross.Core.Models
{
    public class WeatherLocation
    {
        public int Id { get; set; }
        [JsonProperty("city_name")]
        public string City { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}

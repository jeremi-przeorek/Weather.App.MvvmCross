using System.Threading.Tasks;
using MvvmCross.Plugin.Location;
using Xamarin.Essentials;

namespace Weather.App.MvvmCross.Core.Services
{
    public interface ILocationService
    {
        Task<Location> GetCurrentLocationAsync();
    }
}

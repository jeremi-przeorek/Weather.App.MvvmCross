using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Weather.App.MvvmCross.Core.Services
{
    public interface ILocationService
    {
        Task<Location> GetCurrentLocationAsync();
    }
}

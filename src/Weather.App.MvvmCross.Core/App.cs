using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin.Location;
using MvvmCross.ViewModels;
using Weather.App.MvvmCross.Core.Data;
using Weather.App.MvvmCross.Core.ViewModels.General;

namespace Weather.App.MvvmCross.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<IWeatherLocationRepository, WeatherLocationRepository>();
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            RegisterAppStart<GeneralListViewModel>();
        }
    }
}

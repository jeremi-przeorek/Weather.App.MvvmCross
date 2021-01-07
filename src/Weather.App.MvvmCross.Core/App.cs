using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Weather.App.MvvmCross.Core.ViewModels.Home;

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

            RegisterAppStart<HomeViewModel>();
        }
    }
}

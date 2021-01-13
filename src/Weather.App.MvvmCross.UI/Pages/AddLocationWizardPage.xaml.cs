using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Weather.App.MvvmCross.Core.ViewModels.AddLocationWizard;
using Xamarin.Forms.Xaml;

namespace Weather.App.MvvmCross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class AddLocationWizardPage : MvxContentPage<AddLocationWizardViewModel>
    {
        public AddLocationWizardPage()
        {
            InitializeComponent();
        }
    }
}

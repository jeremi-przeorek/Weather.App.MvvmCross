using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Weather.App.MvvmCross.Core.ViewModels.AddLocationFromListWizard;
using Xamarin.Forms.Xaml;

namespace Weather.App.MvvmCross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class AddLocationFromListWizardPage : MvxContentPage<AddLocationFromListWizardViewModel>
    {
        public AddLocationFromListWizardPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
    }
}

using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Weather.App.MvvmCross.Core.ViewModels.General;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.App.MvvmCross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class GeneralListPage : MvxContentPage<GeneralListViewModel>
    {
        public GeneralListPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void OnDelete(object sender, EventArgs e)
        {

        }
    }
}

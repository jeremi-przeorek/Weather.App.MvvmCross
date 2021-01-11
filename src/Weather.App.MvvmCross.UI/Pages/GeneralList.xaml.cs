using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Weather.App.MvvmCross.Core.ViewModels.General;
using Weather.App.MvvmCross.Core.ViewModels.Home;
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

            var set = this.CreateBindingSet<GeneralListPage, GeneralListViewModel>();


            set.Apply();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void OnDelete(object sender, EventArgs e)
        {

        }
    }
}

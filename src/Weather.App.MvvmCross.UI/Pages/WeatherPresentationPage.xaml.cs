using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Syncfusion.SfChart.XForms;
using Weather.App.MvvmCross.Core.ViewModels.WeatherPresentation;
using Xamarin.Forms.Xaml;

namespace Weather.App.MvvmCross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = false)]
    public partial class WeatherPresentationPage : MvxContentPage<WeatherPresentationViewModel>
    {
        public WeatherPresentationPage()
        {
            InitializeComponent();
        }

        private void Chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
        {
            if (e.SelectedDataPointIndex > -1)
            {
            }
        }
    }
}

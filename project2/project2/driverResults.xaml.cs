using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project2.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;


namespace project2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class driverResults : ContentPage
    {
        logicalManager m = new logicalManager();
        ObservableCollection<driverResult>? driverResultList;
        public driverResults()
        {
            InitializeComponent();
            
            
        }
        protected async override void OnAppearing()
        {
            driverResultList = await m.getDriverResultList(logicalManager.driverInUse.driverId);
            driverResultListing.ItemsSource = driverResultList;
            
            base.OnAppearing();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
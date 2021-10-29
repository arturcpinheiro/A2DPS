using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using project2.Modals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DListPage : ContentPage
    {
        ObservableCollection<Driver>? driverList;
        logicalManager m = new logicalManager();
        listManager man = new listManager();

        public DListPage()
        {
            InitializeComponent();
            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            driverList = await m.getDrivers();
            driverListSource.ItemsSource = driverList;
        }

        private async void driverChoose(object sender, SelectedItemChangedEventArgs e)
        {
            // set selected driver
            logicalManager.driverInUse = e.SelectedItem as Driver;
            personalList temp = await listManager.userInp(this.Navigation, new personalList(logicalManager.driverInUse));
            Console.WriteLine(temp + " HEREEEEEE");
            if (temp != null)
            {
                var check = await dbManager.InsertNewDriver(temp);
                if (!check)
                {
                    DisplayAlert("Error", "You already added this Driver.", "Ok");
                }


            }
        }

    }
}
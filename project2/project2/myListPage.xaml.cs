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
    public partial class myListPage : ContentPage
    {
        string query;
        ObservableCollection<personalList> myDriverList;
        ObservableCollection<Driver> myUniqueDriverList = new ObservableCollection<Driver>();
        public myListPage()
        {
            InitializeComponent();
            myDriverList = dbManager.dbDriverList;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            myDriverList = dbManager.dbDriverList;
            myDriverSource.ItemsSource = null;
            myDriverSource.ItemsSource = myDriverList;
        }

        async private void myDriverChoose(object sender, SelectedItemChangedEventArgs e)
        {
            logicalManager.driverInUse = e.SelectedItem as Driver;
            personalList temp = await listManager.userInp(this.Navigation, e.SelectedItem as personalList);
            if (temp != null)
                dbManager.updateDriver(temp);

        }
        async private void myDriverChooseDriverType(object sender, SelectedItemChangedEventArgs e)
        {
            logicalManager.driverInUse = e.SelectedItem as Driver;
            personalList temp = await listManager.userInp(this.Navigation, new personalList(logicalManager.driverInUse));
            if (temp != null)
            {
                if (!await dbManager.InsertNewDriver(temp))
                {
                    DisplayAlert("Error", "You already added this Driver.", "Ok");
                }
                else
                {
                    refresh();
                }
            }

            uniqueDriverSource.ItemsSource = null;      


        }

        public void refresh()
        {
            myDriverSource.ItemsSource = null;
            myDriverSource.ItemsSource = myDriverList;
        }

        private async void deleteItem(object sender, EventArgs e)
        {
            // MenuItem item = (e as MenuItem);
            personalList toDelete = (sender as MenuItem).CommandParameter as personalList;
            if (await dbManager.deleteDriver(toDelete))
            {
                myDriverList.Remove(toDelete);
                refresh();
            }
        }

        void SearchBarChange(Object sender,
           TextChangedEventArgs e)
        {
            query = e.NewTextValue;
        }
        async void searchBarBtn(Object sender,
          EventArgs e)
        {
            myUniqueDriverList.Clear();
            Driver uniqueDriver = await NetworkManager.getDriver(query);
            myUniqueDriverList.Add(uniqueDriver);
            uniqueDriverSource.ItemsSource = null;
            uniqueDriverSource.ItemsSource = myUniqueDriverList;
        }

    }
}
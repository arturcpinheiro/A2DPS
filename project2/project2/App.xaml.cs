using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected async override void OnStart()
        {
            dbManager.createConnection();
            dbManager.dbDriverList = await dbManager.CreateTabel();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

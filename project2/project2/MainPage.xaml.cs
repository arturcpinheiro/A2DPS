using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using project2.Modals;

namespace project2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void toList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DListPage());
        }

        private async void myList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new myListPage());
        }

    }
}

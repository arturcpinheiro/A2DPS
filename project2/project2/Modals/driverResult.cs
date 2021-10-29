using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace project2.Modals
{
    class driverResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string? season { get; set; }
        public string? round { get; set; }
        public string? url { get; set; }
        public string? raceName { get; set; }
        public string? date { get; set; }
        public string time { get; set; }
        public Resultss[]? Results { get; set; }


        public ICommand websiteCalling => new Command(websiteCall);

        private void websiteCall()
        {
            Device.OpenUri(new Uri(url));
        }
    }

    public class Resultss
    {
        public string? number { get; set; }
        public string? position { get; set; }
        public string? positionText { get; set; }
        public string? points { get; set; }
        public string? grid { get; set; }
        public string? laps { get; set; }
        public string? status { get; set; }

    }


}

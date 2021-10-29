using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace project2
{


    public class Driver : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string driverId { get; set; }
        public string? permanentNumber { get; set; }
        public string? code { get; set; }
        public string url { get; set; }

        private string _givenName;
        public string givenName
        {
            get { return _givenName; }
            set
            {
                if (value == _givenName)
                {
                    return;
                }
                _givenName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(givenName)));
                }
            }
        }
        public string familyName { get; set; }
        public string dateOfBirth { get; set; }
        public string nationality { get; set; }

        private string _fullName;
        public string? fullName { get{ return givenName + " " + familyName; }
            set
            {
                if (value == _fullName)
                {
                    return;
                }
                _fullName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(fullName)));
                }
            }
        }

    }
}

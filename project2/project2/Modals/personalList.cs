using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SQLite;

namespace project2.Modals
{
    public class personalList : Driver
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public personalList() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public personalList(Driver d)
        {
            base.code = d.code;
            base.code = d.code;
            base.driverId = d.driverId;
            base.familyName = d.familyName;
            base.givenName = d.givenName;
            base.fullName = d.fullName;
            base.nationality = d.nationality;
            base.url = d.url;
            base.dateOfBirth = d.dateOfBirth;
            base.permanentNumber = d.permanentNumber;
        }

        private string _comments;
        public string comments { 
            set 
            {
                if (value == _comments)
                    return;
                _comments = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(comments)));


            }
            get
            {
                return _comments;
            }
        }

    }
}

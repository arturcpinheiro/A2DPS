using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(project2.Droid.SQLiteDB))]
namespace project2.Droid
{
    public class SQLiteDB : DBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "A2DB.db3");
            return new SQLiteAsyncConnection(path);
        }

    }
}
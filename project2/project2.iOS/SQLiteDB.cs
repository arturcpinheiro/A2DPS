using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(project2.iOS.SQLiteDB))]
namespace project2.iOS
{
    public class SQLiteDB : DBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "A2DB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using project2.Modals;

namespace project2
{
    static public class dbManager
    {
        static SQLiteAsyncConnection _connection;
        static public ObservableCollection<personalList> dbDriverList;
        static public void createConnection()
        {
            _connection = DependencyService.Get<DBInterface>().createSQLiteDB();
        }
        static public async Task<ObservableCollection<personalList>> CreateTabel()
        {
            await _connection.CreateTableAsync<personalList>();
            var driverListDB = await _connection.Table<personalList>().ToListAsync();
            var myListDrivers = new ObservableCollection<personalList>(driverListDB);
            return myListDrivers;
        }
        static public async Task<bool> InsertNewDriver(personalList newDriver)
        {
            if(await existInDb(newDriver.driverId))
            {
                return false;
            }
            else
            {
                int x = await _connection.InsertAsync(newDriver);
                dbDriverList.Add(newDriver);
                return true;

            }
        }
        static public async void updateDriver(personalList DriverUpdate)
        {
            await _connection.UpdateAsync(DriverUpdate);
        }
        static public async Task<bool> deleteDriver(personalList DriverDelete)
        {
            await _connection.DeleteAsync(DriverDelete);
            return true;
        }

        static public async Task<bool> existInDb(string driverId_)
        {
            var queryResult = await _connection.Table<personalList>().Where(x => x.driverId == driverId_).CountAsync();
            return queryResult > 0;
        }
    }
}

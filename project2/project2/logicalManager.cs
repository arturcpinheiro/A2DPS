using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using project2.Modals;

namespace project2
{
    class logicalManager
    {
        ObservableCollection<Driver>? drivers;
        static public Driver driverInUse;
        ObservableCollection<driverResult>? driverResultList;


        public async Task<ObservableCollection<Driver>> getDrivers()
        {
            if (drivers == null)
            {
                var driverList = await NetworkManager.getDrivers();
                drivers = new ObservableCollection<Driver>();
                foreach (Driver i in driverList)
                {
                    drivers.Add(i);
                }
                Console.WriteLine(drivers.Count);
            }
            return drivers;
        }

        public async Task<ObservableCollection<driverResult>> getDriverResultList(string dId)
        {
            if (driverResultList == null)
            {
                var driverRList = await NetworkManager.getDriverResult(dId);
                driverResultList = new ObservableCollection<driverResult>();
                foreach (driverResult i in driverRList)
                {
                    driverResultList.Add(i);
                }
                Console.WriteLine(driverResultList.Count);
            }
            return driverResultList;
        }
    }
}

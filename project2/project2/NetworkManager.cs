using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using project2.Modals;


namespace project2
{
    static class NetworkManager
    {
        static private string url = "https://ergast.com";
        static private string jsonExt = ".json";
        static private string urlDriver = "/api/f1/drivers";


        static HttpClient client = new HttpClient();

        static public async Task<Driver> getDriver(string query)
        {
            string completeURL = url + urlDriver + "/" + query + jsonExt;
            var response = await client.GetAsync(completeURL);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("deu Ruim");
                return new Driver();
            }
            else
            {
                // Desserializing and serializing to get a specific set
                var firstSerial = JsonConvert.SerializeObject(JsonConvert.
                    DeserializeObject<Dictionary<string, object>>(jsonString)["MRData"]);
                var secondSerial = JsonConvert.SerializeObject(JsonConvert.
                    DeserializeObject<Dictionary<string, object>>(firstSerial)["DriverTable"]);
                var lastSerial = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (secondSerial);
                var array = lastSerial["Drivers"];
                var finalList = JsonConvert.DeserializeObject<List<Driver>>
                 (array.ToString());
                //check for result
                if (finalList.Count > 0)
                {
                    return finalList.ElementAt(0);
                    
                }
                else
                {
                    Console.WriteLine("didnt find");
                    return new Driver();
                }

                
            }
        }

        static public async Task<List<Driver>> getDrivers()
        {
            string completeURL = url + urlDriver + jsonExt;
            var response = await client.GetAsync(completeURL);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Driver>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                // Desserializing and serializing to get a specific set
                var firstSerial = JsonConvert.SerializeObject(JsonConvert.
                    DeserializeObject<Dictionary<string, object>>(jsonString)["MRData"]);
                var secondSerial = JsonConvert.SerializeObject(JsonConvert.
                    DeserializeObject<Dictionary<string, object>>(firstSerial)["DriverTable"]);
                var lastSerial = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (secondSerial);
                var array = lastSerial["Drivers"];
                var finalList = JsonConvert.DeserializeObject<List<Driver>>
                 (array.ToString());
                return finalList;
            }
        }

        static public async Task<List<driverResult>> getDriverResult(string driverToUse)
        {
            string completeURL = url + urlDriver + "/" + driverToUse + "/results" + jsonExt;
            var response = await client.GetAsync(completeURL);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<driverResult>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                // Desserializing and serializing to get a specific set
                var firstSerial = JsonConvert.SerializeObject(JsonConvert.
                    DeserializeObject<Dictionary<string, object>>(jsonString)["MRData"]);
                var secondSerial = JsonConvert.SerializeObject(JsonConvert.
                    DeserializeObject<Dictionary<string, object>>(firstSerial)["RaceTable"]);
                var lastSerial = JsonConvert.DeserializeObject<Dictionary<string, object>>
                    (secondSerial);
                var array = lastSerial["Races"];
                var finalList = JsonConvert.DeserializeObject<List<driverResult>>
                 (array.ToString());
                //Console.WriteLine(finalList.ElementAt(0));

                return finalList;
            }
        }

    }
}

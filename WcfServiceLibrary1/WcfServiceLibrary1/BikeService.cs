using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace SOAPBike
{
    class BikeService : IBikeService
    {
        private const string cred = "a3f1a3079fb702635ae5def736dc687e65b222db";


        public int AvailableBike(string city, string station)
        {
            WebRequest req = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=" + cred);
            WebResponse ans = req.GetResponse();

            Stream stream = ans.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string strAns = reader.ReadToEnd();
            Station[] stations = JsonConvert.DeserializeObject<Station[]>(strAns);

            List<string> res = new List<string>();

            foreach (Station current in stations)
            {
                if (current.name.Contains(station))
                {
                    return current.available_bike_stands;
                }
            }
            return -1;
        }

        public string[] ListCity()
        {
            WebRequest req = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + cred);
            WebResponse ans = req.GetResponse();

            Stream stream = ans.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string strAns = reader.ReadToEnd();
            City[] stations = JsonConvert.DeserializeObject<City[]>(strAns);

            List<string> res = new List<string>();

            foreach (City city in stations)
            {
                res.Add(city.name);
            }

            return res.ToArray();
        }

        public string[] ListStation(string city)
        {
            WebRequest req = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=" + cred);
            WebResponse ans = req.GetResponse();

            Stream stream = ans.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string strAns = reader.ReadToEnd();
            Station[] stations = JsonConvert.DeserializeObject<Station[]>(strAns);

            List<string> res = new List<string>();

            foreach(Station station in stations)
            {
                res.Add(station.name);
            }

            return res.ToArray();
        }
    }
}

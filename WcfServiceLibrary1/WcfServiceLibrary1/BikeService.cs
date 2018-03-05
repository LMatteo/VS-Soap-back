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
        public static int refreshTime = 10;
        public static string cred = "a3f1a3079fb702635ae5def736dc687e65b222db";
        private static Cache<City[]> cityCache = new CityCache(refreshTime);
        private static Dictionary<string, Cache<Station[]>> cacheMap = new Dictionary<string, Cache<Station[]>>();

        public int AvailableBike(string city, string station)
        {
            Station[] stations;
            try
            {
                stations = cacheMap[city].GetContent();
            }
            catch (KeyNotFoundException)
            {
                Cache<Station[]> cache = new StationCache(refreshTime, city);
                cacheMap.Add(city, cache);
                stations = cache.GetContent();
            }

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

            City[] cities = cityCache.GetContent();

            List<string> res = new List<string>();

            foreach (City city in cities)
            {
                res.Add(city.name);
            }

            return res.ToArray();
        }

        public string[] ListStation(string city)
        {
            Station[] stations;
            try
            {
                stations = cacheMap[city].GetContent();
            }
            catch (KeyNotFoundException)
            {
                Cache<Station[]> cache = new StationCache(refreshTime, city);
                cacheMap.Add(city, cache);
                stations = cache.GetContent();
            }


            List<string> res = new List<string>();

            foreach(Station station in stations)
            {
                res.Add(station.name);
            }

            return res.ToArray();
        }
    }
}

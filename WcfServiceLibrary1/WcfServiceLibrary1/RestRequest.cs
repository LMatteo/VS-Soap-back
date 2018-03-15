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
    class RestRequest
    {
        public static int nbReq = 0;
        public static City[] getCityListReq()
        {
            nbReq++;
            try
            {
                WebRequest req = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + BikeService.cred);
                WebResponse ans = req.GetResponse();

                Stream stream = ans.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string strAns = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<City[]>(strAns);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new City[0];
            }
        }

        public static Station[] getStationList(string city)
        {
            nbReq++;
            try
            {
                WebRequest req = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=" + BikeService.cred);
                WebResponse ans = req.GetResponse();

                Stream stream = ans.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                string strAns = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Station[]>(strAns);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new Station[0];
            }
        }
    }
}

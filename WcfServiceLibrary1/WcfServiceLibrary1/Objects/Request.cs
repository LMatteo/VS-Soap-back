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
    public interface IRequest
    {
        long getExecTime();
    }

    abstract class Request<T> : IRequest
    {
        private long execTime;

        protected abstract T ExecRequest();

        public T Exec()
        {
            RequestMetrics.nbReq++;
            RequestMetrics.AddRequest(this);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            T val = ExecRequest();
            watch.Stop();
            this.execTime = watch.ElapsedMilliseconds;
            return val;
        }

        public long getExecTime()
        {
            return this.execTime;
        }
    }

    class CityRequest : Request<City[]>
    {
        protected override City[] ExecRequest()
        {
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
    }

    class StationRequest : Request<Station[]>
    {
        private string city;

        public StationRequest(string city)
        {
            this.city = city;
        }

        protected override Station[] ExecRequest()
        {
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

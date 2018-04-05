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
    
    abstract class Cache<T>
    {
        protected T content;
        private DateTime lastRefresh;
        public static int freshTime;
        private bool isSubscribed = false;

        // freshTime : time in second before content need to be fetch again
        public Cache(int refreshTime)
        {
            freshTime = refreshTime;
        }

        public Cache()
        {
            freshTime = 10;
        }

        private bool IsUpToDate()
        {
            if (content == null) return false;
            return (DateTime.Now - lastRefresh).Seconds < freshTime;
        }

        private void RefreshContent()
        {
            this.Refresh();
            lastRefresh = DateTime.Now;
            
        }

        public async void Subsribe()
        {
            while (true)
            {
                SubscribeMethod();
                await Task.Delay(freshTime*100);
            }
        }

        protected abstract void Refresh();
        protected abstract void SubscribeMethod();

        public T GetContent()
        {
            if (IsUpToDate())
            {
                return this.content;
            } else
            {
                this.RefreshContent();
                return this.content;
            }
        }
    }

    class CityCache : Cache<City[]>
    {
        public static int nbRefresh = 0;
        public CityCache(int freshTime) : base(freshTime)
        {
        }

        protected override void Refresh()
        {
            CityRequest req = new CityRequest();
            this.content = req.Exec();
            nbRefresh++;

        }

        protected override void SubscribeMethod()
        {
            throw new NotImplementedException();
        }
    }

    class StationCache : Cache<Station[]>
    {
        public static int nbRefresh = 0;
        private string city;

        public StationCache(int freshTime, string city) : base(freshTime)
        {
            this.city = city;
        }

        protected override void Refresh()
        {
            StationRequest req = new StationRequest(city);
            this.content = req.Exec();
            nbRefresh++;
        }

        protected override void SubscribeMethod()
        {
            foreach(Station station in this.content)
            {
                SOAPBike.EventService.BikeService.update(this.city, station.ToString());
            }
        }
    }

}

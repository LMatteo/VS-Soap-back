﻿using System;
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

        protected abstract void Refresh();

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
        public CityCache(int freshTime) : base(freshTime)
        {
        }

        protected override void Refresh()
        {
            CityRequest req = new CityRequest();
            this.content = req.Exec();

        }
    }

    class StationCache : Cache<Station[]>
    {
        private string city;

        public StationCache(int freshTime, string city) : base(freshTime)
        {
            this.city = city;
        }

        protected override void Refresh()
        {
            StationRequest req = new StationRequest(city);
            this.content = req.Exec();
        }
    }

}

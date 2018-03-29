using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPBike
{
    class MonitorService : IMonitorService
    {
        public long AverageExecTime()
        {
            return RequestMetrics.GetAverageExecTime();
        }

        public int getCityCacheRefresh()
        {
            return CityCache.nbRefresh;
        }

        public int getCityCacheRefreshTime()
        {
            return CityCache.freshTime;
        }

        public long getMaxExecTime()
        {
            return RequestMetrics.getMaxExecTime();
        }

        public long getMinExecTime()
        {
            return RequestMetrics.getMinExecTime();
        }

        public int getStationCacheRefresh()
        {
            return StationCache.nbRefresh;
        }

        public int getStationCacheRefreshTime()
        {
            return StationCache.freshTime;
        }

        public string[] getUrlList()
        {
            return RequestMetrics.getUrlList();
        }

        public int NbRequest()
        {
            return RequestMetrics.nbReq;
        }

        public void setCityCacheRefreshTime(int time)
        {
            CityCache.freshTime = time;
        }

        public void setStationCacheRefreshTime(int time)
        {
            StationCache.freshTime = time;
        }

    }
}

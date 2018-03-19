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

        public int getCityCacheRefreshTime()
        {
            return CityCache.
        }

        public int getStationCacheRefreshTime()
        {
            throw new NotImplementedException();
        }

        public int NbRequest()
        {
            return RequestMetrics.nbReq;
        }

        public void setCityCacheRefreshTime(int time)
        {
            throw new NotImplementedException();
        }

        public void setStationCacheRefreshTime(int time)
        {
            throw new NotImplementedException();
        }
    }
}

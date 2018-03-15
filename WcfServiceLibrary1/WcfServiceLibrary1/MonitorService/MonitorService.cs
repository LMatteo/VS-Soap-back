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

        public int NbRequest()
        {
            return RequestMetrics.nbReq;
        }
    }
}

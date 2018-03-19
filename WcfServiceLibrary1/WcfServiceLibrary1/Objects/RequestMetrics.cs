using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPBike
{
    class RequestMetrics
    {
        public static int nbReq = 0;
        public static List<IRequest> requests = new List<IRequest>();

        public static void AddRequest(IRequest req)
        {
            requests.Add(req);
        }

        public static long GetAverageExecTime()
        {
            if (requests.Count == 0) return 0;

            long res = 0;
            
            foreach(IRequest request in requests)
            {
                res += request.getExecTime() / requests.Count;
            }

            return res;
        }

    }
}

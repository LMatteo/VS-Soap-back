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

        public static long getMaxExecTime()
        {
            long max = 0;

            foreach(IRequest req in requests)
            {
                if(req.getExecTime() > max)
                {
                    max = req.getExecTime();
                }
            }
            return max;
        }

        public static long getMinExecTime()
        {
            if (requests.Count == 0) return 0;

            long min = long.MaxValue;

            foreach (IRequest req in requests)
            {
                if (req.getExecTime() < min)
                {
                    min = req.getExecTime();
                }
            }
            return min;
        }

        public static string[] getUrlList()
        {
            List<string> urls = new List<string>();

            foreach(IRequest req in requests)
            {
                if (!urls.Contains(req.getUrl()))
                {
                    urls.Add(req.getUrl());
                }
            }

            return urls.ToArray<string>();
        }

    }
}

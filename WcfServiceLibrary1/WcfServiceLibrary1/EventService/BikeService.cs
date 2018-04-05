using System;
using System.Text;
using System.ServiceModel;
using System.Collections.Generic;

namespace SOAPBike.EventService
{
    class BikeService : IBikeService
    {
        static Dictionary<string, Action<string>> EventTable = new Dictionary<string, Action<string>>();

        public void SubscribeStation(string city)
        {
            IBikeServiceEvent subscriber = OperationContext.Current.GetCallbackChannel<IBikeServiceEvent>();
            try
            {
                EventTable[city] += subscriber.BikeChange;
            }
            catch
            {
                EventTable[city] = delegate { };
                EventTable[city] += subscriber.BikeChange;
            }

            SOAPBike.BikeService.CreateCache(city);
            SOAPBike.BikeService.cacheMap[city].Subsribe();
        }

        public static void update(string city, string up)
        {   
            EventTable[city](up);   
        }
    }
}

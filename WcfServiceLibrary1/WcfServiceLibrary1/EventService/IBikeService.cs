using System;
using System.Text;
using System.ServiceModel;

namespace SOAPBike.EventService
{
    [ServiceContract(CallbackContract = typeof(IBikeServiceEvent))]
    interface IBikeService
    {
        [OperationContract]
        void SubscribeStation(string city);
    }
}

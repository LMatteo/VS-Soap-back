using System;
using System.Text;
using System.ServiceModel;


namespace SOAPBike.EventService
{
    interface IBikeServiceEvent
    {
        [OperationContract(IsOneWay = true)]
        void BikeChange(string cities);
    }
}

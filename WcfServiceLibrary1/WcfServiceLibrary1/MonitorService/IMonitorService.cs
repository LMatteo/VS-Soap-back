using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace SOAPBike
{
    [ServiceContract]
    interface IMonitorService
    {
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int NbRequest();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract] 
        long AverageExecTime();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int getCityCacheRefreshTime();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        void setCityCacheRefreshTime(int time);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int getStationCacheRefreshTime();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        void setStationCacheRefreshTime(int time);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        long getMaxExecTime();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        long getMinExecTime();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        string[] getUrlList();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int getCityCacheRefresh();

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int getStationCacheRefresh();
    }
}

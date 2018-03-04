using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IMathsOperation
    {
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int add(int a, int b);

        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        int multiply(int a, int b);
    }
}

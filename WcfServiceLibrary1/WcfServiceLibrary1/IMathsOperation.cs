using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IMathsOperation
    {
        [OperationContract]
        int add(int a, int b);

        [OperationContract]
        int multiply(int a, int b);
    }
}

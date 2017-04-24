using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace WCFRESTShoppingCartSample
{
    [MessageContract]
    public class FunctionResult
    {
        [MessageBodyMember]
        public string Message;
    }

    [DataContract(Namespace = "")]
    public class StockChangeValue
    {
        [DataMember]
        public int ProductID { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
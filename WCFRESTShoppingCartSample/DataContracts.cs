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

    [MessageContract]
    public class StockChangeValue
    {
        [MessageBodyMember]
        public int ProductID { get; set; }

        [MessageBodyMember]
        public int Count { get; set; }
    }

    [MessageContract]
    public class ProductInput
    {
        [MessageBodyMember]
        public string id { get; set; }
    }

    [MessageContract]
    public class CustomerInput
    {
        [MessageBodyMember]
        public string UserID { get; set; }
    }
}
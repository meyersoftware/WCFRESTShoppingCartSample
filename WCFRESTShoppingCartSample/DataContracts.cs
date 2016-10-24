using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFRESTShoppingCartSample
{
    [DataContract]
    public class FunctionResult
    {
        [DataMember]
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
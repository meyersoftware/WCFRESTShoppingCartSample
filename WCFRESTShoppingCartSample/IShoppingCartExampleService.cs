using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml.Linq;

namespace WCFRESTShoppingCartSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShoppingCartSampleService" in both code and config file together.
    [ServiceContract]
    [DataContractFormatAttribute]
    public interface IShoppingCartExampleService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetProduct")]
        Message GetProduct(Message ID);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetCustomer")]
        Message GetCustomer(Message id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "AddStock")]
        [ServiceKnownType(typeof(StockChangeValue))]
        FunctionResult AddStock(StockChangeValue scv);
    }
}

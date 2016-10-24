using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace WCFRESTShoppingCartSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShoppingCartSampleService" in both code and config file together.
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IShoppingCartExampleService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetProduct/{id}")]
        string GetProduct(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetCustomer/{id}")]
        string GetCustomer(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "AddStock")]
        [ServiceKnownType(typeof(StockChangeValue))]
        FunctionResult AddStock(StockChangeValue scv);
    }
}

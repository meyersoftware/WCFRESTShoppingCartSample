using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace WCFRESTShoppingCartSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShoppingCartSampleService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShoppingCartSampleService.svc or ShoppingCartSampleService.svc.cs at the Solution Explorer and start debugging.
    public class ShoppingCartSampleService : IShoppingCartExampleService
    {
        public FunctionResult AddStock(StockChangeValue scv)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                ShoppingCartExampleEntities2 dc = new ShoppingCartExampleEntities2();
                {
                    dc.AddStock(scv.ProductID, scv.Count);
                    result.Message = true.CreateJsonResponse().ToString();
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.CreateJsonResponse().ToString();
            }
            return result;
        }

        public Message GetProduct(ProductInput productId)
        {
            try
            {
                ShoppingCartExampleEntities2 dc = new ShoppingCartExampleEntities2();
                {

                    var products = dc.GetProduct(int.Parse(productId.ProductID)).ToList();

                    return products.CreateJsonResponse();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.CreateJsonResponse();
            }
        }

        public Message GetCustomer(CustomerInput userId)
        {
            try
            {
                ShoppingCartExampleEntities2 dc = new ShoppingCartExampleEntities2();
                {

                    var customers = dc.GetCustomer(userId.UserID).ToList();

                    return customers.CreateJsonResponse();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.CreateJsonResponse();
            }
        }
    }

    public static class JSONFun
    {
        public static Message CreateJsonResponse(this object obj)
        {
        string msg = JsonConvert.SerializeObject(obj);

        return WebOperationContext.Current.CreateTextResponse(msg, "application/json; charset=utf-8", Encoding.UTF8);
        }
    }
}

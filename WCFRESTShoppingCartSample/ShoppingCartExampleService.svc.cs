using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
        public FunctionResult AddStock (StockChangeValue scv)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                using (ShoppingCartExampleEntities dc = new ShoppingCartExampleEntities())
                {
                    dc.AddStock(scv.ProductID, scv.Count);
                    result.Message = true.ToJSON();
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.ToJSON();
            }
            return result;
        }

        public string GetProduct(string productId)
        {
            try
            {
                using (ShoppingCartExampleEntities dc = new ShoppingCartExampleEntities())
                { 

                    var products = dc.GetProduct(int.Parse(productId)).ToList();

                    return products.ToJSON();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToJSON();
            }
        }

        public string GetCustomer(string userId)
        {
            try
            {
                using (ShoppingCartExampleEntities dc = new ShoppingCartExampleEntities())
                { 

                    var customers = dc.GetCustomer(userId).ToList();

                    return customers.ToJSON();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToJSON();
            }
        }
    }

    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }
    }
}

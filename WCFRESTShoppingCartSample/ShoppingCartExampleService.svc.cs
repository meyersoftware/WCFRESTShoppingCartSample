using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
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
                using (DataShoppingCartExampleDataContext dc = new WCFRESTShoppingCartSample.DataShoppingCartExampleDataContext())
                {
                    dc.AddStock(scv.ProductID, scv.Count);
                    result.Message = "true";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public string GetProduct(string productId)
        {
            try
            {
                using (DataShoppingCartExampleDataContext dc = new WCFRESTShoppingCartSample.DataShoppingCartExampleDataContext())
                { 

                    List<Product> products = dc.GetProduct(int.Parse(productId)).ToList();

                    var productslist = from pl in products
                                       select new XElement("Product",
                                       new XElement("ProductID", pl.ProductID),
                                       new XElement("Name", pl.Name),
                                       new XElement("ProductDescription", pl.ProductDescription),
                                       new XElement("Price", pl.Price),
                                       new XElement("Stock", pl.Stock)
                                       );

                    var reportXML = new XElement("Product", productslist);

                    return reportXML.ToString();
                }
            }
            catch (Exception ex)
            {
                XDocument doc = new XDocument();
                doc.Add(new XElement("root", new XElement("error", ex.Message)));
                return doc.ToString();
            }
        }

        public string GetCustomer(string userId)
        {
            try
            {
                using (DataShoppingCartExampleDataContext dc = new WCFRESTShoppingCartSample.DataShoppingCartExampleDataContext())
                { 

                    List<Customer> customers = dc.GetCustomer(userId).ToList();

                    var customerinfo = from ci in customers
                                       select new XElement("Customer",
                                       new XElement("FirstName", ci.Firstname),
                                       new XElement("Middlename", ci.Middlename),
                                       new XElement("Lastname", ci.Lastname),
                                       new XElement("Address", ci.Address),
                                       new XElement("Address2", ci.Address2),
                                       new XElement("City", ci.City),
                                       new XElement("State", ci.State),
                                       new XElement("Zip", ci.Zip)
                                       );

                    var reportXML = new XElement("Customer", customerinfo);

                    return reportXML.ToString();
                }
            }
            catch (Exception ex)
            {
                XDocument doc = new XDocument();
                doc.Add(new XElement("root", new XElement("error", ex.Message)));
                return doc.ToString();
            }
        }
    }
}

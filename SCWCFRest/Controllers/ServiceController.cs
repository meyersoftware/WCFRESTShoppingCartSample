using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects;

namespace SCWCFRest.Controllers
{
    public class ServiceController : ApiController
    {
        // GET: api/Service
        public List<GetProduct_Result> Get()
        {
            using (SCWCFRest.db6d71ab021b7344fe97f9a75f0150b4eaEntities DB = new db6d71ab021b7344fe97f9a75f0150b4eaEntities())
            {
                var products = DB.GetProduct(0).ToList();
                JsonResult test = new JsonResult();
                test.Data = products;
                return products;
            }
        }

        // GET: api/Service/5
        public List<GetProduct_Result> Get(int id)
        {
            using (SCWCFRest.db6d71ab021b7344fe97f9a75f0150b4eaEntities DB = new db6d71ab021b7344fe97f9a75f0150b4eaEntities())
            {
                var products = DB.GetProduct(id).ToList();
                JsonResult test = new JsonResult();
                test.Data = products;
                return products;
            }
        }

        // POST: api/Service
        [System.Web.Mvc.HttpGet]
        public int GetCustomer(string customer)
        {
            int customerID = 0;
            using (SCWCFRest.db6d71ab021b7344fe97f9a75f0150b4eaEntities DB = new db6d71ab021b7344fe97f9a75f0150b4eaEntities())
            {
                Customer c = JsonConvert.DeserializeObject<Customer>(customer);

                customerID = DB.InsertCustomer("0", c.Firstname, c.Middlename, c.Lastname,
                    c.Address, c.Address2, c.City, c.State, c.Zip);
            }
            return customerID;
        }

        

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
        }
    }
}

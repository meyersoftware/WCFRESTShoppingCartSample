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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Service
        public void Post([FromBody]string value)
        {
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

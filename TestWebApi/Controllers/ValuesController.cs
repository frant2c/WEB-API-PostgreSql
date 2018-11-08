using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebApi;

namespace WebTestApplication.Controllers
{
    public class ValuesController : ApiController
    {
        ShopContext db = new ShopContext();

        // GET api/values

        public string Get(int Purchase, int Product)
        {
            return Get(Purchase, Product);
        }

        // GET api/values/5


        public IQueryable<Object> Get()
        {
            return from a in db.Purchases
                   join p in db.Products on a.ProductId equals p.Id
                   select new
                   {
                       customer_name = a.CustomerName,
                       product_name = p.Name,
                       customer_size = p.Size
                   };
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

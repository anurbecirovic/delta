using Billing.Api.Models;
using Billing.Database;
using Billing.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Billing.Api.Controllers
{
    [RoutePrefix("api/suppliers")]
    public class SuppliersController : ApiController
    {
        public IBillingRepository<Supplier> suppliers = new BillingRepository<Supplier>(new BillingContext());
        Factory factory = new Factory();
        //public IHttpActionResult Get()
        //{   return Ok(agents.Get().ToList())

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(suppliers.Get().ToList().Select(x => factory.Create(x)).ToList());
        }

        //------
        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            return Ok(suppliers.Get().Where(x => x.Name.Contains(name)).ToList()
                                  .Select(a => factory.Create(a)).ToList());
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Supplier supplier = suppliers.Get(id);
            if (supplier == null) return NotFound();
            return Ok(factory.Create(supplier));
        }

        

    }
}

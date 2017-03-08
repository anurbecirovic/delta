using Billing.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Billing.Api.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : BaseController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(UnitOfWork.Customers.Get().ToList().Select(x => Factory.Create(x)).ToList());
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Customer customer = UnitOfWork.Customers.Get(id);
            if (customer == null) return NotFound();
            return Ok(Factory.Create(customer));
        }

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            return Ok(UnitOfWork.Customers.Get().Where(x => x.Name.Contains(name)).ToList().Select(a => Factory.Create(a)).ToList());

        }
    }
}

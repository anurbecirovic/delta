using Billing.Api.Models;
using Billing.Database;
using Billing.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Billing.Api.Controllers
{
    [RoutePrefix("api/agents")]
    public class AgentsController : ApiController
    {
        public IBillingRepository<Agent> agents = new BillingRepository<Agent>(new BillingContext());
        Factory factory = new Factory();
        //public IHttpActionResult Get()
        //{   return Ok(agents.Get().ToList())

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(agents.Get().ToList().Select(x => factory.Create(x)).ToList());
        }
       
        //------
        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            return Ok(agents.Get().Where(x => x.Name.Contains(name)).ToList()
                                  .Select(a => factory.Create(a)).ToList());
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Agent agent = agents.Get(id);
            if (agent == null) return NotFound();
            return Ok(factory.Create(agent));
        }       
    }
}

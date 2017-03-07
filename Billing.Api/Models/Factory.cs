using Billing.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing.Api.Models
{
    public class Factory
    {
        public AgentModel Create(Agent agent)
        {
            AgentModel model = new AgentModel()
            {
                Id = agent.Id,
                Name = agent.Name
            };

            foreach (Town town in agent.Towns.Where(x => x.Customers.Count != 0).ToList())
            {
                model.Towns.Add(town.Name);
            }
            return model;
        }


        public SupplierModel Create(Supplier supplier)
        {
            SupplierModel model = new SupplierModel()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address
            };

            foreach (Procurement procurement in supplier.Procurements.Where(x => x.Price > 500 ).ToList())
            {
                model.Procurements.Add(procurement.Document);
            }
            return model;
        }
    }
}


using Billing.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing.Api.Models
{
    public class Factory
    {
        private BillingContext context;
        public Factory(BillingContext _context)
        {
            context = _context;
        }

        public AgentModel Create(Agent agent)
        {
            return new AgentModel()
            {
                Id = agent.Id,
                Name = agent.Name,
                Towns = agent.Towns.Where(x => x.Customers.Count != 0).Select(x => x.Name).ToList()
            };
        }

        public CategoryModel Create(Category category)
        {
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Count
            };
        }

        public ProductModel Create(Product product)
        {
            return new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category.Name,
                Unit = product.Unit,
                Stock = (product.Stock == null) ? 0 : (int)(product.Stock.Input - product.Stock.Output)
            };
        }

        public SupplierModel Create(Supplier supplier)
        {
            return new SupplierModel()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                Town = supplier.Town.Name
            };

        }

        public TownModel Create(Town town)
        {
            return new TownModel()
            {
                Id = town.Id,
                Name = town.Name,
                Region = town.Region.ToString(),
                Customers = town.Customers.Select(x => x.Name).ToList(),
                Agents = town.Agents.Select(x => x.Name).ToList()
            };

        }

        public ItemModel Create(Item item)
        {
            return new ItemModel()
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Price = item.Price,
                SubTotal = item.SubTotal
            };

        }
    }
}


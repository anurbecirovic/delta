using Billing.Database;
using Billing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing.Api.Models
{
    public class Factory
    {
        private UnitOfWork _unitOfWork;
        public Factory(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private BillingContext context;
        public Factory(BillingContext _context)
        {
            context = _context;
        }

        //All together
        public AgentModel Create(Agent agent)
        {
            return new AgentModel()
            {
                Id = agent.Id,
                Name = agent.Name,
                Towns = agent.Towns.Where(x => x.Customers.Count != 0).Select(x => x.Name).ToList()
            };
        }

        //All together
        public CategoryModel Create(Category category)
        {
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Count
            };
        }

        //All together
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

        //Denis
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

        //Denis
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

        //Denis
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

        //Anur
        public ProcurementsModel Create(Procurement procurements)
        {
            return new ProcurementsModel()
            {
                Id = procurements.Id,
                Document = procurements.Document,
                Date = procurements.Date,
                Quantity = procurements.Quantity,
                Price = procurements.Price,
                Product = procurements.Product.Name,
                Supplier = procurements.Supplier.Name
            };
        }

        //Josip
        public ShipperModel Create(Shipper shipper)
        {
            return new ShipperModel()
            {
                Id = shipper.Id,
                Name = shipper.Name,
                Address = shipper.Address,
                Town = shipper.Town.Name,
                Invoices = shipper.Invoices.Select(x => x.InvoiceNo).ToList(),
                TownId=shipper.Town.Id
            };
        }

        public Shipper Create(ShipperModel model)
        {
            return new Shipper()
            {
                Id=model.Id,
                Name=model.Name,
                Address=model.Address,
                Town = _unitOfWork.Towns.Get(model.TownId)
            };
        }

        //Josip
        public CustomerModel Create(Customer customer)
        {
            return new CustomerModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                Town = customer.Town.Name,
                Invoices = customer.Invoices.Select(x => x.InvoiceNo).ToList(),
                TownId = customer.Town.Id
            };
        }


        public Customer Create(CustomerModel model)
        {
            return new Customer()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Town=_unitOfWork.Towns.Get(model.TownId)
            };
        }

        //Josip
        public InvoiceModel Create(Invoice invoice)
        {
            return new InvoiceModel()
            {
                Id = invoice.Id,
                InvoiceNo = invoice.InvoiceNo,
                Date = invoice.Date,
                Shipper = invoice.Shipper.Name,
                Customer = invoice.Customer.Name,
                Agent = invoice.Agent.Name,
                Total = invoice.Total,
                Shipping = invoice.Shipping,
                ShipperId=invoice.Shipper.Id,
                AgentId=invoice.Agent.Id,
                CustomerId=invoice.Customer.Id
            };
        }

        public Invoice Create(InvoiceModel model)
        {
            return new Invoice()
            {
                Id = model.Id,
                InvoiceNo = model.InvoiceNo,
                Date = model.Date,
                Shipping=model.Shipping,
                Agent = _unitOfWork.Agents.Get(model.AgentId),
                Customer = _unitOfWork.Customers.Get(model.CustomerId),
                Shipper = _unitOfWork.Shippers.Get(model.ShipperId)

            };
        }
    }
}


using ComissionCalculator.ApiModels;
using ComissionCalculator.DAL;
using ComissionCalculator.Models;
using ComissionCalculator.Services.Contracts;

namespace ComissionCalculator.Services
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly ComissionDbContext _dbContext;

        public InvoiceItemService(ComissionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public InvoiceItem Create(InvoiceItemApi invoiceItem)
        {
            var product = _dbContext.Products.FirstOrDefault(product => product.Name == invoiceItem.Product);
            if (product == null)
            {
                product = new Product
                {
                    Name = invoiceItem.Product,
                    Price = invoiceItem.Price
                };

                product = _dbContext.Products.Add(product).Entity;
            }

            var newInvoiceItem = new InvoiceItem
            {
                Product = product,
                Price = invoiceItem.Price,
                Amount = invoiceItem.Amount,
            };

            return newInvoiceItem;
        }
    }
}

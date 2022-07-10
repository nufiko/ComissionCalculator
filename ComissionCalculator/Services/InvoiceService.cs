using ComissionCalculator.ApiModels;
using ComissionCalculator.DAL;
using ComissionCalculator.Mapper;
using ComissionCalculator.Models;
using ComissionCalculator.Services.Contracts;

namespace ComissionCalculator.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ComissionDbContext _dbContext;
        private readonly ISalesPersonService _salesPersonService;
        private readonly IInvoiceItemService _invoiceItemService;
        private readonly IComissionService _comissionService;

        public InvoiceService(ComissionDbContext dbContext, ISalesPersonService salesPersonService, IInvoiceItemService invoiceItemService, IComissionService comissionService)
        {
            _dbContext = dbContext;
            _salesPersonService = salesPersonService;
            _invoiceItemService = invoiceItemService;
            _comissionService = comissionService;
        }

        public Invoice Create(InvoiceApi invoice)
        {
            var salesPerson = _salesPersonService.Get(invoice.SalesPerson);

            if(salesPerson == null)
            {
                return null;
            }

            var invoiceItems = invoice.Products.Select(product => _invoiceItemService.Create(product));

            var newInvoice = new Invoice
            {
                SalesPerson = salesPerson,
                Products = invoiceItems.ToList(),
                SalesDate = invoice.SalesDate
            };

            var comission = _comissionService.CalculateComission(newInvoice);

            newInvoice.Comission = comission;

            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges();

            return newInvoice;
        }
    }
}

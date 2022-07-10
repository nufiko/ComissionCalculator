using ComissionCalculator.ApiModels;
using ComissionCalculator.DAL;
using ComissionCalculator.Mapper;
using ComissionCalculator.Models;
using ComissionCalculator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        ComissionDbContext _dbContext;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper<Invoice, InvoiceApi> _invoiceMapper;

        public InvoiceController(ComissionDbContext context, IInvoiceService invoiceService, IMapper<Invoice, InvoiceApi> invoiceMapper)
        {
            _dbContext = context;
            _invoiceService = invoiceService;
            _invoiceMapper = invoiceMapper;
        }

        [HttpGet("[action]")]
        public ActionResult<InvoiceApi> Get(int id)
        {
            var invoice = _dbContext.Invoices
                .Include(i => i.SalesPerson)
                .Include(i => i.Products).ThenInclude(p => p.Product)
                .FirstOrDefault(i => i.Id == id);

            if(invoice == null)
            {
                return NotFound();
            }

            return Ok(_invoiceMapper.Map(invoice));
        }

        [HttpPost("[action]")]
        public ActionResult<InvoiceApi> Add([FromBody] InvoiceApi invoice)
        {
            var newInvoice = _invoiceService.Create(invoice);
            return Created(Url.ActionContext.ToString(), _invoiceMapper.Map(newInvoice));
        }
    }
}

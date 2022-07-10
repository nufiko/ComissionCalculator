using ComissionCalculator.ApiModels;
using ComissionCalculator.Models;

namespace ComissionCalculator.Mapper
{
    public class InvoiceMapper : IMapper<Invoice, InvoiceApi>
    {

        IMapper<SalesPerson, SalesPersonApi> _salesPersonMapper;
        IMapper<InvoiceItem, InvoiceItemApi> _invoiceItemMapper;

        public InvoiceMapper(IMapper<SalesPerson, SalesPersonApi> salesPersonMapper, IMapper<InvoiceItem, InvoiceItemApi> invoiceItemMapper)
        {
            _salesPersonMapper = salesPersonMapper;
            _invoiceItemMapper = invoiceItemMapper;
        }

        public InvoiceApi Map(Invoice source)
        {
            var result = new InvoiceApi
            {
                Id = source.Id,
                SalesPerson = _salesPersonMapper.Map(source.SalesPerson),
                Products = source.Products.Select(product => _invoiceItemMapper.Map(product)).ToList(),
                SalesDate = source.SalesDate,
                Comission = source.Comission
            };

            return result;
        }
    }
}

using ComissionCalculator.ApiModels;
using ComissionCalculator.Models;

namespace ComissionCalculator.Mapper
{
    public class InvoiceItemMapper : IMapper<InvoiceItem, InvoiceItemApi>
    {
        public InvoiceItemApi Map(InvoiceItem source)
        {
            var result = new InvoiceItemApi
            {
                Product = source.Product.Name,
                Amount = source.Amount,
                Price = source.Price
            };

            return result;
        }
    }
}

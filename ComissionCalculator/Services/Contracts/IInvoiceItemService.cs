using ComissionCalculator.ApiModels;
using ComissionCalculator.Models;

namespace ComissionCalculator.Services.Contracts
{
    public interface IInvoiceItemService
    {
        InvoiceItem Create(InvoiceItemApi invoiceItem);
    }
}

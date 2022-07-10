using ComissionCalculator.ApiModels;
using ComissionCalculator.Models;

namespace ComissionCalculator.Services.Contracts
{
    public interface IInvoiceService
    {
        Invoice Create(InvoiceApi invoice);
    }
}

using ComissionCalculator.ApiModels;
using ComissionCalculator.Mapper;
using ComissionCalculator.Models;
using ComissionCalculator.Services;
using ComissionCalculator.Services.Contracts;

namespace ComissionCalculator.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IComissionService, ComissionService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceItemService, InvoiceItemService>();
            services.AddScoped<ISalesPersonService, SalesPersonService>();
            services.AddSingleton<IMapper<Invoice, InvoiceApi>, InvoiceMapper>();
            services.AddSingleton<IMapper<InvoiceItem, InvoiceItemApi>, InvoiceItemMapper>();
            services.AddSingleton<IMapper<SalesPerson, SalesPersonApi>, SalesPersonMapper>();

            return services;
        }
    }
}

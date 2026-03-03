
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SalesContext.UseCases.Categories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Credence.Application.SalesContext.UseCases.Extensions;

public static class SalesDIExtension
{
    public static void AddSalesServices(this WebApplicationBuilder builder)
    {
        builder
               .Services
               .AddTransient<ICategoryHandler, CategoryHandler>();

        builder
               .Services
               .AddTransient<ITransactionHandler, TransactionHandler>();
    }
}


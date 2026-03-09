using Credence.Application.SalesContext.Product.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Domain.SalesContext.Entities;
using Credence.Infrastructure.SharedContext.UseCases.Responses;

namespace Credence.Application.SharedContext.Contracts.Sales;

public interface IProductHandler
{
    Task<PagedResponse<List<Product?>>> GetAllAsync(GetAllProductsRequest request);
    Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request);
}

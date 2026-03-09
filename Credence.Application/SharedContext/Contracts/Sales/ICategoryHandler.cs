using Credence.Application.SalesContext.Categories.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Domain.SalesContext.Entities;
using Credence.Infrastructure.SharedContext.UseCases.Responses;

namespace Credence.Application.SharedContext.Contracts.Sales;

public interface ICategoryHandler
{
    Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
    Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
    Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
}

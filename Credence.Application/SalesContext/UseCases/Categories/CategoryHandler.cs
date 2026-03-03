

using Credence.Default.Messages;
using Credence.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Credence.Infrastructure.SharedContext.UseCases.Responses;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SalesContext.UseCases.Categories.Requests;
using Credence.Domain.SalesContext.Entities;

namespace Credence.Application.SalesContext.UseCases.Categories;

public class CategoryHandler(CredenceDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var category = new Category(request.Title,request.Description)
            {
                UserId = request.UserId,
            };

            await context.Categories.AddAsync(category);

            await context.SaveChangesAsync();

            return new Response<Category?>(category, StatusCodes.Status201Created, Successes.Created);
        }
        catch
        {
            return new Response<Category?>(null, StatusCodes.Status404NotFound, Errors.CreateFail);
        }
    }
    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var categoryById = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (categoryById is null)
                return new Response<Category?>(null, StatusCodes.Status404NotFound, Errors.NotFound);

            context.Categories.Remove(categoryById);

            await context.SaveChangesAsync();

            return new Response<Category?>(categoryById, message: Successes.Updated);
        }
        catch
        {
            return new Response<Category?>(null, StatusCodes.Status404NotFound, Errors.UpdateFailed);
        }
    }
    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {

            var categoryById = await context
            .Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            return categoryById is null ?
                    new Response<Category?>(
                        null,
                        StatusCodes.Status404NotFound,
                        Errors.NotFound
                    )
                    :
                    new Response<Category?>(categoryById);

        }
        catch
        {

            return new Response<Category?>(
                    null,
                    StatusCodes.Status404NotFound,
                    Errors.FailedRetrieve
                    );
        }
    }
    public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            var query = Query(context, request.UserId);

            if (query is null)
                return new PagedResponse<List<Category>>(null, StatusCodes.Status404NotFound, Errors.NotFound);

            var categories = await Paginator(query, request.DefaultPagination(), request.PageSize);

            var count = await query.CountAsync();

            return PagedResponseBuilder(categories,count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Category>>(null, StatusCodes.Status500InternalServerError, Errors.FailedRetrieve);
        }
    }
    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var categoryById = await context
                .Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (categoryById is null)
                return new Response<Category?>(null, StatusCodes.Status404NotFound, Errors.NotFound);
            
            categoryById.Update(request.Title, request.Description);

            context.Categories.Update(categoryById);

            await context.SaveChangesAsync();

            return new Response<Category?>(categoryById, message: Successes.Updated);
        }
        catch
        {
            return new Response<Category?>(null, StatusCodes.Status404NotFound, Errors.UpdateFailed);
        }
    }

    private IOrderedQueryable<Category> Query(CredenceDbContext context, Guid userId)
    {
        return context.Categories
                       .AsNoTracking()
                       .Where(x => x.UserId == userId)
                       .OrderBy(x => x.Title);
    }
    private async Task<List<Category>> Paginator(IOrderedQueryable<Category> query, int skip, int take)
    {
        return await query
           .Skip(skip)
           .Take(take)
           .ToListAsync();
    }

    private PagedResponse<List<Category>> PagedResponseBuilder(List<Category> categories, int count, int pageNumber, int pageSize)
    {
        return categories is null
        ? new PagedResponse<List<Category>>(null, StatusCodes.Status404NotFound, Errors.NotFound)
        : new PagedResponse<List<Category>>(categories, count, pageNumber, pageSize);
    }

}
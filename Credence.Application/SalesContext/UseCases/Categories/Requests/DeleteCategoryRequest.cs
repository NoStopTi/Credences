

using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.UseCases.Categories.Requests;

public class DeleteCategoryRequest : Request
{
    public Guid Id { get; set; }
}
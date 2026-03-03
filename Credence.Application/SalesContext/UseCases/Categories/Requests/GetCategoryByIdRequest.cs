
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.UseCases.Categories.Requests;

public class GetCategoryByIdRequest : Request
{
    public Guid Id { get; set; }
}
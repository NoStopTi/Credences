
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Product.Requests;

public class GetProductBySlugRequest: Request
{
    public string Slug { get; private set; } = string.Empty;
}
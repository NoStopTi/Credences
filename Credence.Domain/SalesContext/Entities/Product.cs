namespace Credence.Domain.SalesContext.Entities;

public class Product
{
    public long Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
    public decimal Price { get; private set; }

}



using System.ComponentModel.DataAnnotations;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;
using Credence.Domain.SharedContext.Entities;

namespace Credence.Domain.SalesContext.Entities;
public class Category :Entity
{
    public Category() { }
    public Category(string title, string description)
    {
        if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Description))
            throw new ArgumentNullException(nameof(Title));

        Title = title;
        Description = description;
    }

    [MaxLength(CategoryConst.TitleMax, ErrorMessage = CategoryConst.TitleMaxMsg)]
    [Required(ErrorMessage = CategoryConst.TitleRequired)]
    public string Title { get; private set; } = string.Empty;


    [MaxLength(CategoryConst.DescriptionMax, ErrorMessage = CategoryConst.DescriptionMaxMsg)]
    public string? Description { get; private set; }

    public void Update(string title, string description)
    {
        if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Description))
            throw new ArgumentNullException(nameof(Title));

        Title = title;
        Description = description;
    }

}
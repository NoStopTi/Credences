

using System.ComponentModel.DataAnnotations;
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.UseCases.Categories.Requests;

public class UpdateCategoryRequest : Request
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Invalid title")]
    [MaxLength(80, ErrorMessage = "The title must be up to 80 characters long")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid description")]
    public string Description { get; set; } = string.Empty;

}


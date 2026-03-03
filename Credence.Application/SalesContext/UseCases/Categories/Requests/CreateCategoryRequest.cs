

using System.ComponentModel.DataAnnotations;
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.UseCases.Categories.Requests;

public class CreateCategoryRequest : Request
{
    
    [Required(ErrorMessage = "Título inválido")]
    [MaxLength(80, ErrorMessage = "O título deve conter até 80 caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Descrição inválida")]
    public string Description { get; set; } = string.Empty;

}
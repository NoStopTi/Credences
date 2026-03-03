using System.ComponentModel.DataAnnotations.Schema;
using Credence.Domain.CompanyContext.Entities;
using Credence.Domain.SharedContext.Entities;
using Credence.Domain.UserContext.ValueObjects;

namespace Credence.Domain.BusinessContext.Entities;

public class Business : Entity
{
    [NotMapped]
    private readonly ICollection<Company> _companies = [];
    public Business()
    {

    }
    public Business(Name name)
    {
        Name = name;
    }
    public Name? Name { get; set; }
    public IReadOnlyCollection<Company> Companies => _companies.ToList();

    [NotMapped]
    public override Guid CompanyId { get; set; } = Guid.Empty;

    public void AddCompany(Company company)
    {
        _companies.Add(company);
    }

}
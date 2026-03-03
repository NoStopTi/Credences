
using System.ComponentModel.DataAnnotations.Schema;
using Credence.Domain.AuthContext.Entities;
using Credence.Domain.BusinessContext.Entities;
using Credence.Domain.CompanyContext.ValueObjects;
using Credence.Domain.ProfileContext.Entities;
using Credence.Domain.SharedContext.Entities;
using Credence.Domain.SharedContext.ValueObjects;


namespace Credence.Domain.CompanyContext.Entities;

public class Company : Entity
{
    protected Company() { }
    public Company(Guid businessId,
                    Address address,
                    Contact contact,
                    CompanyName companyName,
                    CompanyStatus status,
                    TaxId taxId)
    {
        BusinessId = businessId;
        Address = address;
        Contact = contact;
        CompanyName = companyName;
        Status = status;
        TaxId = taxId;
    }
    public CompanyName CompanyName { get; private set; } = null!;
    public CompanyStatus Status { get; private set; } = null!;
    public Guid BusinessId { get; private set; }
    public Business Business { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public Contact Contact { get; private set; } = null!;
    public TaxId TaxId { get; private set; } = null!; // CNPJ / CPF
    public ICollection<UserCompany> UserCompanies { get; private set; } = null!;

    [NotMapped]
    public override Guid CompanyId { get; set; }

}
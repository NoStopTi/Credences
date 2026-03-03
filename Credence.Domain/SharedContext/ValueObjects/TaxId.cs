using Credence.Default.DomainContext.Entities.Constants.SharedContext;
namespace Credence.Domain.SharedContext.ValueObjects;

public class TaxId : ValueObject
{
    public TaxId()
    {

    }
    public TaxId(string value)
    {
        if (value.IsCnpj())
            CNPJ = value;

        if (value.IsCpf())
            CPF = value;

        if (!value.IsTaxIdValid())
            AddNotification(nameof(value), TaxIdConst.Invalid);
    }
    public string? CNPJ { get; private set; } = string.Empty;
    public string? CPF { get; private set; } = string.Empty;


    public bool Validate(string source)
    {
        var cnpj = string.IsNullOrEmpty(CNPJ);
        var cpf = string.IsNullOrEmpty(CPF);

        if (!cnpj)
        {
            if (!CNPJ!.IsTaxIdValid())
                AddNotification(source, TaxIdConst.Invalid);
        }
        return IsValid;
    }

}
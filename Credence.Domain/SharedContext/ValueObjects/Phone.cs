using Credence.Domain.SharedContext.ValueObjects.Validations;

namespace Credence.Domain.SharedContext.ValueObjects;

public class Phone : ValueObject
{

    public Phone() { }

    public string? Landline { get; private set; } = string.Empty;
    public string? Mobile { get; private set; } = string.Empty;
    public string? Work { get; private set; } = string.Empty;
    public string? Home { get; private set; } = string.Empty;
    public string? WhatsApp { get; private set; } = string.Empty;
    public string? Telegram { get; private set; } = string.Empty;
    public string? Skype { get; private set; } = string.Empty;
    public string? Other { get; private set; } = string.Empty;

    public Phone BuildLandline(string value)
    {
        Landline = value;

        return this;
    }
    public Phone BuildMobile(string value)
    {
        Mobile = value;
        return this;
    }
    public Phone BuildWork(string value)
    {
        Work = value;
        return this;
    }
    public Phone BuildHome(string value)
    {
        Home = value;
        return this;
    }
    public Phone BuildWhatsApp(string value)
    {
        WhatsApp = value;
        return this;
    }
    public Phone BuildTelegram(string value)
    {
        Telegram = value;
        return this;
    }
    public Phone BuildSkype(string value)
    {
        Skype = value;
        return this;
    }
    public Phone BuildOther(string value)
    {
        Other = value;
        return this;
    }

    public bool Validate(string source)
    {
        new PhoneValidation(this, source);
        return IsValid;
    }


}

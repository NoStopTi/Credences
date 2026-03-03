
using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Domain.SharedContext.ValueObject.Abstractions;
using Flunt.Validations;

namespace Credence.Domain.SharedContext.ValueObjects.Validations;

public class PhoneValidation : Contract<Phone>, IValidate
{
    private readonly Phone _phone;
    public PhoneValidation(Phone phone, string source)
    {
      _phone = phone;
      Validate(source);
    }

    private void CheckSpecificity(Phone phones, string source)
    {
        var properties = typeof(Phone).GetProperties();

        var result = properties
                   .Where(
                    x => !string.IsNullOrWhiteSpace($"{x.GetValue(phones)}")
                   ).ToList();

        result.ForEach(x =>
        {

            if (Validators().TryGetValue(x.Name, out var validate))
            {
                var value = typeof(Phone).GetProperty(x.Name)!.GetValue(phones, null);
                validate(value?.ToString() ?? string.Empty, source);
            }
        });

    }

    private Dictionary<string, Action<string, string>> Validators() =>

    new Dictionary<string, Action<string, string>>
    {
        {nameof(PhoneConst.LandlineValue),ValidateLandline},
        {nameof(PhoneConst.MobileValue),ValidateMobile},
        {nameof(PhoneConst.WorkValue),ValidateWork},
        {nameof(PhoneConst.HomeValue),ValidateHome},
        {nameof(PhoneConst.WhatsAppValue),ValidateWhatsApp},
        {nameof(PhoneConst.TelegramValue),ValidateTelegram},
        {nameof(PhoneConst.SkypeValue),ValidateSkype},
        {nameof(PhoneConst.OtherValue),ValidateOther},
    };

    public void ValidateLandline(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.LandlineMax,
                     $"{source}-{PhoneConst.LandlineMaxMsg}");
    }
    public void ValidateMobile(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.MobileMax,
                     $"{source}-{PhoneConst.MobileMaxMsg}");
    }
    public void ValidateWork(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.WorkMax,
                     $"{source}-{PhoneConst.WorkMaxMsg}");
    }
    public void ValidateHome(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.HomeMax,
                     $"{source}-{PhoneConst.HomeMaxMsg}");
    }
    public void ValidateWhatsApp(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.WhatsAppMax,
                     $"{source}-{PhoneConst.WhatsAppMaxMsg}");
    }
    public void ValidateTelegram(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.TelegramMax,
                     $"{source}-{PhoneConst.TelegramMaxMsg}");
    }
    public void ValidateSkype(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.SkypeMax,
                     $"{source}-{PhoneConst.SkypeMaxMsg}");
    }
    public void ValidateOther(string value, string source)
    {
        Requires().IsLowerOrEqualsThan(value,
                     PhoneConst.OtherMax,
                     $"{source}-{PhoneConst.OtherMaxMsg}");
    }
    public void AtLeastOne(Phone phones, string source)
    {
        var properties = typeof(Phone).GetProperties();

        var result = properties.Any(x => !string.IsNullOrWhiteSpace($"{x.GetValue(phones)}"));

        if (!result)
            AddNotification(source, PhoneConst.Required);
    }

    public  bool Validate(string source)
    {
         AtLeastOne(_phone, source);
        CheckSpecificity(_phone, source);

        return IsValid;
    }
}

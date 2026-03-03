using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Domain.ProfileContext.Entities.Validations;
using Credence.Domain.ProfileContext.Interfaces;
using Credence.Domain.SharedContext.Entities;

namespace Credence.Domain.ProfileContext.Entities;

public class Address : Entity, ICountry,
                       IStreet,
                       INumber,
                       INeighborhood,
                       ICity,
                       IState,
                       IZipCode,
                       IComplement,
                       IIsValidAddress
{

    private static Address _address = new();
    public static ICountry Build() => _address;
    public Address() { }
    public string Country { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;
    public string Complement { get; private set; } = string.Empty;

    public INeighborhood SetCity(string value)
    {
        AddNotifications(new AddressValidation(this));
        _address.City = value;
        return this;
    }

    public IComplement SetComplement(string value)
    {
        _address.Complement = value;
        return this;
    }

    public IState SetCountry(string value)
    {
        _address.Country = value;
        return this;
    }

    public IStreet SetNeighborhood(string value)
    {
        _address.Neighborhood = value;
        return this;
    }

    public IIsValidAddress SetNumber(string value)
    {
        _address.Number = value;
        return this;
    }

    public ICity SetState(string value)
    {
        _address.State = value;
        return this;
    }

    public INumber SetStreet(string value)
    {
        _address.Street = value;
        return this;
    }

    public IZipCode SetZipCode(string value)
    {
        _address.ZipCode = value;
        return this;
    }
    public Address IsValidAddress()
    {

        var result = string.IsNullOrEmpty(_address.Country) ||
                     string.IsNullOrEmpty(_address.Street) ||
                     string.IsNullOrEmpty(_address.Number) ||
                     string.IsNullOrEmpty(_address.Neighborhood) ||
                     string.IsNullOrEmpty(_address.City) ||
                     string.IsNullOrEmpty(_address.State) ||
                     string.IsNullOrEmpty(_address.ZipCode) ||
                     string.IsNullOrEmpty(_address.Complement);

        if (result)
            throw new ArgumentException(AddressConst.Required, nameof(Address));

        return _address;

    }
}
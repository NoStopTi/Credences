using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Flunt.Validations;

namespace Credence.Domain.ProfileContext.Entities.Validations;

public class AddressValidation : Contract<Address>
{
    public AddressValidation(Address address)
    {
        IsNullOrEmpty(address.Complement, nameof(address.Complement), AddressConst.Required)
            .IsGreaterThan(address.Complement, AddressConst.ComplementMax, AddressConst.ComplementMaxMsg);

        Requires()
            .IsNullOrEmpty(address.Country, nameof(address.Country), AddressConst.Required)
            .IsGreaterThan(address.Country, AddressConst.CountryMax, AddressConst.CountryMaxMsg)

            .IsNullOrEmpty(address.Street, nameof(address.Street), AddressConst.Required)
            .IsGreaterThan(address.Street, AddressConst.StreetMax, AddressConst.StreetMaxMsg)

            .IsNullOrEmpty(address.Number, nameof(address.Number), AddressConst.Required)
            .IsGreaterThan(address.Number, AddressConst.NumberMax, AddressConst.NumberMaxMsg)

            .IsNullOrEmpty(address.Neighborhood, nameof(address.Neighborhood), AddressConst.Required)
            .IsGreaterThan(address.Neighborhood, AddressConst.NeighborhoodMax, AddressConst.NeighborhoodMaxMsg)

            .IsNullOrEmpty(address.City, nameof(address.City), AddressConst.Required)
            .IsGreaterThan(address.City, AddressConst.CityMax, AddressConst.CityMaxMsg)

            .IsNullOrEmpty(address.State, nameof(address.State), AddressConst.Required)
            .IsGreaterThan(address.State, AddressConst.StateMax, AddressConst.StateMaxMsg)

            .IsNullOrEmpty(address.ZipCode, nameof(address.ZipCode), AddressConst.Required)

            .IsGreaterThan(address.ZipCode, AddressConst.ZipCodeMax, AddressConst.ZipCodeMaxMsg);
    }
}

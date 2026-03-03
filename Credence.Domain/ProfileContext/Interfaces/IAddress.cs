
using Credence.Domain.ProfileContext.Entities;

namespace Credence.Domain.ProfileContext.Interfaces;


public interface ICountry
{
    IState SetCountry(string value);
}


public interface IStreet
{
    INumber SetStreet(string value);
}


public interface INumber
{
    IIsValidAddress SetNumber(string value);
}


public interface INeighborhood
{
    IStreet SetNeighborhood(string value);
}


public interface ICity
{
    INeighborhood SetCity(string value);
}
public interface IState
{
    ICity SetState(string value);
}


public interface IZipCode
{
    IZipCode SetZipCode(string value);
}


public interface IComplement
{
    IComplement SetComplement(string value);
}
public interface IIsValidAddress
{
    Address IsValidAddress();
}



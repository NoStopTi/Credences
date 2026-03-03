using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Domain.ProfileContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {

        EntityBaseMapping.Configure(builder);
        
        builder.ToTable(AddressConst.ToTable);

        builder.Property(a => a.Street)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.StreetMax)
            .IsRequired();

        builder.Property(a => a.Number)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.NumberMax)
            .IsRequired();

        builder.Property(a => a.Complement)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.ComplementMax)
            .IsRequired(false);

        builder.Property(a => a.Neighborhood)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.NeighborhoodMax)
            .IsRequired();

        builder.Property(a => a.City)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.CityMax)
            .IsRequired();

        builder.Property(a => a.State)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.StateMax)
            .IsRequired();

        builder.Property(a => a.ZipCode)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.ZipCodeMax)
            .IsRequired(false);

        builder.Property(a => a.Country)
            .HasColumnType(AddressConst.HasColumnType)
            .HasMaxLength(AddressConst.CountryMax)
            .IsRequired()
            .HasDefaultValue(AddressConst.CountryHasDefaultValue);
    }
}
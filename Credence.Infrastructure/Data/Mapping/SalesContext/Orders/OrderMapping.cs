using Credence.Default.Constants.UserContext;
using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

using Credence.Domain.SalesContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {

        // EntityBaseMapping.Configure(builder);

        builder.ToTable(AddressConst.ToTable);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
        .IsRequired()
        .HasColumnType(OrderConst._CHAR)
        .HasMaxLength(OrderConst._MaxNumber);

        builder.Property(x => x.ExternalReference)
        .IsRequired()
        .HasColumnType(OrderConst._VARCHAR)
        .HasMaxLength(OrderConst._MaxExternalReference);

        builder.Property(x => x.Gateway)
        .IsRequired()
        .HasColumnType(OrderConst._SMALLINT);

        builder.Property(x => x.CreateAt)
        .IsRequired()
        .HasColumnType(OrderConst._DATETIME2);

        builder.Property(x => x.UpdatedAt)
        .IsRequired()
        .HasColumnType(OrderConst._DATETIME2);

        builder.Property(x => x.Status)
              .IsRequired()
              .HasColumnType(OrderConst._SMALLINT);

        builder.Property(x => x.UserId)
                              .IsRequired()
                             .HasColumnType(UserConst.IdHasColumnType);

    }
}
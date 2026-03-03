
using Credence.Default.Constants.EmailContext;
using Credence.Domain.SharedContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class EntityBaseMapping
{
    public static void Configure<T>(EntityTypeBuilder<T> builder) where T : Entity
    {
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.Notifications);

        builder.Property(x => x.Id)
        .HasColumnName("Id")
        .HasColumnType("BINARY(16)");

        builder.Property(x => x.UserId)
        .HasColumnName("UserId")
        .HasColumnType("BINARY(16)");

        builder.Property(x => x.CompanyId)
        .HasColumnName("CompanyId")
        .HasColumnType("BINARY(16)");

        builder.Property(x => x.CreatedAt)
     .IsRequired()
     .HasColumnType("DATETIME(6)");

        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnType("DATETIME(6)");

        builder.Property(x => x.IsDeletedAt)
            .IsRequired()
            .HasColumnType("DATETIME(6)");

        builder.Property(e => e.Email)
           .HasColumnName("Email")
           .HasColumnType("VARCHAR")
           .HasMaxLength(EmailConst.Max)
           .IsRequired();

    }

}
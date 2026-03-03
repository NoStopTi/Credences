using Credence.Default.DomainContext.Entities.Constants.BusinessContext;
using Credence.Domain.BusinessContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class BusinessMapping : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        EntityBaseMapping.Configure(builder);

        builder.ToTable(BusinessConst.ToTable);

        builder.HasMany(x => x.Companies)
                        .WithOne(x => x.Business)
                            .HasForeignKey(x => x.BusinessId);

        builder.OwnsOne(x => x.Name, name =>
        {
             name.Ignore(x=> x.Notifications);
             name.Ignore(x=> x.LastName);
             name.Ignore(x=> x.DisplayName);

            name.Property(x => x.FirstName)
                 .IsRequired()
                    .HasColumnName(BusinessConst.NameValue)
                        .HasColumnType(BusinessConst.NameHasColumnType)
                            .HasMaxLength(BusinessConst.NameMax);

        });
    }
}
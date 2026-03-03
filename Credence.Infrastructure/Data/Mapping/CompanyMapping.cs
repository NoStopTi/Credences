using Credence.Default.DomainContext.Entities.Constants.CompanyContext;
using Credence.Default.DomainContext.Entities.Constants.SharedContext;
using Credence.Domain.CompanyContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        EntityBaseMapping.Configure(builder);

        //PF_ == ProFile
        builder.ToTable($"PF_Companies");

        // builder.HasKey(x => x.Id);

        // builder.Property(x => x.Id)
        // .HasColumnName("Id")
        // .HasColumnType("BINARY(16)");

        builder.OwnsOne(x => x.CompanyName,
            companyName =>
            {
                //FLUNT
                companyName.Ignore(x => x.Notifications);

                companyName.Property(x => x.LegalName)
                     .HasColumnName("LegalName")
                     .HasColumnType("VARCHAR")
                     .HasMaxLength(CompanyNameConst.LegalNameMax)
                     .IsRequired();

                companyName.Property(x => x.TradeName)
                   .HasColumnName("TradeName")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(CompanyNameConst.TradeNameMax)
                   .IsRequired();
            }
            );

        builder.OwnsOne(x => x.TaxId, taxId =>
        {
            //FLUNT
            taxId.Ignore(x => x.Notifications);
            taxId.Ignore(x => x.CPF);


            taxId.Property(x => x.CNPJ)
                .HasColumnName("CNPJ")
                .HasColumnType("VARCHAR")
                .HasMaxLength(TaxIdConst.CpfMax)
                .IsRequired(false);
        });

        builder.OwnsOne(x => x.Status, status =>
        {
            status.Ignore(x => x.Notifications);

            status.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnName("IsActive")
            .HasColumnType("TINYINT");


            status.Property(x => x.LastStatusChanged)
            .HasColumnName("LastStatusChanged")
            .IsRequired()

            .HasColumnType("DATETIME(6)");

        });

    }
}
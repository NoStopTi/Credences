using Credence.Domain.AuthContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class UserCompanyMapping : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {

        //AU_ == Authentication
        builder.ToTable($"AU_UserCompanies");

        builder.HasKey(x => new { x.UserId,  x.CompanyId });

        builder
        .HasOne(x=> x.User)
        .WithMany(x=> x.UserCompanies)
        .HasForeignKey(x=>x.UserId)
        .IsRequired();
        
        builder
        .HasOne(x=> x.Company)
        .WithMany(x=> x.UserCompanies)
        .HasForeignKey(x=>x.CompanyId)
        .IsRequired();


        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("DATETIME(6)");

        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnType("DATETIME(6)");

        builder.Property(x => x.IsDeletedAt)
            .IsRequired()
            .HasColumnType("DATETIME(6)");
    }
}
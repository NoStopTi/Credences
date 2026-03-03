using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Credence.Infrastructure.Data.Mapping.IdentityMap;

public class IdentityRoleClaimMapping : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRoleClaim<Guid>> builder)
    {
        //AU_ == Authentication
        builder.ToTable("AU_RoleClaims");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
        .HasColumnName("Id")
        .HasColumnType("BINARY(16)");

        builder.Property(x => x.ClaimType).HasMaxLength(RoleClaimConst.ClaimTypeMax);
        builder.Property(x => x.ClaimValue).HasMaxLength(RoleClaimConst.ClaimValueMax);
    }
}

using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping.IdentityMap;

public class IdentityUserLoginMapping : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        //AU_ == Authentication
        builder.ToTable("AU_UserLogins");
        builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });
        builder.Property(x => x.LoginProvider).HasMaxLength(UserLoginConst.LoginProviderMax);
        builder.Property(x => x.ProviderKey).HasMaxLength(UserLoginConst.ProviderKeyMax);
        builder.Property(x => x.ProviderDisplayName).HasMaxLength(UserLoginConst.ProviderDisplayNameMax);
    }
}
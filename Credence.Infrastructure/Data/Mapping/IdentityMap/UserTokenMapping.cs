

using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Credence.Infrastructure.Data.Mapping.IdentityMap;

public class IdentityUserTokenMapping : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
        //AU_ == Authentication
        builder.ToTable("AU_UserTokens");
        builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        builder.Property(x => x.LoginProvider).HasMaxLength(IdentityUserTokenConst.LoginProviderMax);
        builder.Property(x => x.Name).HasMaxLength(IdentityUserTokenConst.NameMax);
    }
}


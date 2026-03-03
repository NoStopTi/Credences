using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Credence.Domain.AuthContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Credence.Infrastructure.Data.Mapping.IdentityMap;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.ToTable(RoleConst.ToTable);
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.Id).HasColumnName(RoleConst.IdHasColumnName)
                                   .HasColumnType(RoleConst.IdHasColumnType);

        //builder.HasIndex(x => x.NormalizedName).IsUnique();
        builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();
        builder.Property(x => x.Name).HasMaxLength(RoleConst.NameMax);


        builder.Property(x => x.DisplayRoleName).HasMaxLength(RoleConst.DisplayRoleNameMax);


        builder.Property(x => x.NormalizedName).HasMaxLength(RoleConst.NormalizedNameMax);

        builder.HasData(new Role
        {
           Id = Guid.Parse(RoleConst.AdminIdGuid),
           Name = RoleConst.AdminRoleName,
           NormalizedName = RoleConst.AdminNormalizedName,
           DisplayRoleName = RoleConst.AdminDisplayRoleName,
           ConcurrencyStamp = Guid.Parse(RoleConst.AdminConcurrencyStampGuid).ToString(),
        });

        builder.HasData(new Role
        {
           Id = Guid.Parse(RoleConst.TwoFactorPendingIdGuid),
           Name = RoleConst.TwoFactorRolePendingName,
           NormalizedName = RoleConst.TwoFactorNormalizedName,
           DisplayRoleName = RoleConst.TwoFactorDisplayRoleName,
           ConcurrencyStamp = Guid.Parse(RoleConst.TwoFactorConcurrencyStampGuid).ToString(),
        });

    }
}
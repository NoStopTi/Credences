
using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.PasswordContext;
using Credence.Default.Constants.UserContext;
using Credence.Default.DomainContext.Entities.Constants.SharedContext;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping.IdentityMap;

public class IdentityUserMapping : IEntityTypeConfiguration<User>
{
       public void Configure(EntityTypeBuilder<User> builder)
       {
              #region PROPERTIES_CONF
              builder.ToTable(UserConst.ToTable);

              builder.HasKey(u => u.Id);

              builder.Property(x => x.Id)
                     .HasColumnName(UserConst.IdHasColumnName)
                     .HasColumnType(UserConst.IdHasColumnType);

              builder.HasIndex(u => u.NormalizedUserName)
                     .IsUnique();

              builder.Property(x => x.Email)
                     .HasColumnName(EmailConst.EmailHasColumnName)
                     .HasMaxLength(EmailConst.EmailMax)
                     .IsRequired();

              builder.HasIndex(u => u.NormalizedEmail)
                     .IsUnique();

              builder.Property(u => u.NormalizedEmail)
                     .HasMaxLength(UserConst.NormalizedEmailMax);

              builder.Property(u => u.UserName)
                     .HasMaxLength(UserConst.UserNameMax);

              builder.Property(u => u.NormalizedUserName)
                     .HasMaxLength(UserConst.NormalizedUserNameMax);

              builder.Property(u => u.PhoneNumber)
                     .HasMaxLength(UserConst.PhoneNumberMax);

              builder.Property(u => u.ConcurrencyStamp)
                     .IsConcurrencyToken();

              builder.HasMany<IdentityUserClaim<Guid>>()
                     .WithOne()
                     .HasForeignKey(uc => uc.UserId).IsRequired();

              builder.HasMany<IdentityUserLogin<Guid>>()
                     .WithOne()
                     .HasForeignKey(ul => ul.UserId).IsRequired();

              builder.HasMany<IdentityUserToken<Guid>>()
                     .WithOne()
                     .HasForeignKey(ut => ut.UserId).IsRequired();

              #endregion
              #region ValueObjects
              builder.OwnsOne(x => x.Name, name =>
              {
                     //FLUNT       
                     name.Ignore(x => x.Notifications);

                     name.Property(x => x.FirstName)
                   .HasColumnName(NameConst.FirstNameHasColumnName)
                   .HasMaxLength(NameConst.FirstNameMax);

                     name.Property(x => x.LastName)
                   .HasColumnName(NameConst.LastNameHasColumnName)
                   .HasMaxLength(NameConst.LastNameMax);

                     name.Property(x => x.DisplayName)
                   .HasColumnName(NameConst.DisplayNameHasColumnName)
                   .HasMaxLength(NameConst.DisplayNameMax);
              });
              builder.OwnsOne(x => x.LoginOptions, lastLogin =>
              {
                     //FLUNT
                     lastLogin.Ignore(x => x.Notifications);
                     lastLogin.Property(x => x.LastLogin)
                  .HasColumnName(UserConst.LastLoginValue);
              });
              builder.OwnsOne(x => x.PasswordExpire, pwdExpire =>
                   {
                          //FLUNT
                          pwdExpire.Ignore(x => x.Notifications);
                          pwdExpire.Property(x => x.PasswordChangedAt)
                    .HasColumnName(PasswordConst.PasswordChangedAtHasColumnName);
                   });
              builder.OwnsOne(x => x.SendCodeByEmailDisabledAt, twoFactor =>
                            {
                                   //FLUNT
                                   twoFactor.Ignore(x => x.Notifications);
                                   twoFactor.Property(x => x.SendCodeByEmailDisabledAt)
                                  .HasColumnName(TwoFactorConst.HasColumnNameCodeByEmail);
                            });
                            
              builder.OwnsOne(x => x.Image, img =>
              {
                     //FLUNT
                     img.Ignore(x => x.Notifications);
                     img.Property(x => x.Value)
                  .HasColumnName(ImageConst.HasColumnName)
                  .HasMaxLength(ImageConst.ImageMax);
              });
              builder.OwnsOne(x => x.Age, age =>
              {
                     //FLUNT
                     age.Ignore(x => x.Notifications);

                     age.Property(x => x.Value)
                  .HasColumnName(AgeConst.HasColumnName)
                  .HasColumnType(AgeConst.HasColumnType)
                  .HasMaxLength(AgeConst.AgeMax);
              });
              builder.OwnsOne(x => x.Gender, gender =>
              {
                     //FLUNT
                     gender.Ignore(x => x.Notifications);

                     gender.Property(x => x.Value)
                  .HasColumnName(GenderConst.HasColumnName)
                  .HasColumnType(GenderConst.HasColumnType)
                  .HasMaxLength(GenderConst.GenderMax);
              });
           
              #endregion
       }
}
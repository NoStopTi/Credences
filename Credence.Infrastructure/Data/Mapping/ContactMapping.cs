using Credence.Default.Constants.EmailContext;
using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Domain.ProfileContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {

        EntityBaseMapping.Configure(builder);

        builder.ToTable(ContactConst.ToTable);


        builder.OwnsOne(x => x.WebSite, webSite =>
        {
            //FLUNT
            webSite.Ignore(x => x.Notifications);

            webSite.Property(c => c.Url)
          .HasColumnName(ContactConst.WebSiteValue)
          .HasMaxLength(ContactConst.WebSiteMax)
          .IsRequired(false);

        });


        builder.OwnsOne(x => x.Phone, phones =>
        {
            //FLUNT
            phones.Ignore(x => x.Notifications);

            phones.Property(p => p.Landline)
           .HasColumnName(PhoneConst.LandlineValue)
           .HasColumnType(PhoneConst.HasColumnType)
           .HasMaxLength(PhoneConst.LandlineMax)
           .IsRequired(false);

            phones.Property(p => p.Mobile)
           .HasColumnName(PhoneConst.MobileValue)
           .HasColumnType(PhoneConst.HasColumnType)
           .HasMaxLength(PhoneConst.MobileMax)
           .IsRequired(false);

            phones.Property(p => p.Work)
           .HasColumnName(PhoneConst.WorkValue)
           .HasColumnType(PhoneConst.HasColumnType)
           .HasMaxLength(PhoneConst.WorkMax)
           .IsRequired(false);

            phones.Property(p => p.Home)
                .HasColumnName(PhoneConst.HomeValue)
                .HasColumnType(PhoneConst.HasColumnType)
                .HasMaxLength(PhoneConst.HomeMax)
                .IsRequired(false);

            phones.Property(p => p.WhatsApp)
                .HasColumnName(PhoneConst.WhatsAppValue)
                .HasColumnType(PhoneConst.HasColumnType)
                .HasMaxLength(PhoneConst.WhatsAppMax)
                .IsRequired(false);

            phones.Property(p => p.Telegram)
                .HasColumnName(PhoneConst.TelegramValue)
                .HasColumnType(PhoneConst.HasColumnType)
                .HasMaxLength(PhoneConst.TelegramMax)
                .IsRequired(false);

            phones.Property(p => p.Skype)
                .HasColumnName(PhoneConst.SkypeValue)
                .HasColumnType(PhoneConst.HasColumnType)
                .HasMaxLength(PhoneConst.SkypeMax)
                .IsRequired(false);

            phones.Property(p => p.Other)
                .HasColumnName(PhoneConst.OtherValue)
                .HasColumnType(PhoneConst.HasColumnType)
                .HasMaxLength(PhoneConst.OtherMax)
                .IsRequired(false);

        });

        builder.Property(c => c.Email)
           .HasColumnName(EmailConst.EmailHasColumnName)
           .HasColumnType(PhoneConst.HasColumnType)
           .HasMaxLength(EmailConst.Max)
           .IsRequired();


        builder.OwnsMany(x => x.SocialNetworks, socialNetworks =>
            {

                //FLUNT
                socialNetworks.Ignore(x => x.Notifications);

                socialNetworks.ToTable(SocialNetworkConst.ToTable);
                socialNetworks.HasKey(x => x.Id);

                socialNetworks.Property(x => x.Id)
                .HasColumnName(SocialNetworkConst.IdHasColumnName)
                .HasColumnType(SocialNetworkConst.IdHasColumnType);

                socialNetworks.Property(c => c.Name)
                 .HasColumnType(SocialNetworkConst.NameUrlHasColumnType)
                 .HasMaxLength(SocialNetworkConst.NameMax)
                 .IsRequired();

                socialNetworks.Property(c => c.Url)
                           .HasColumnType(SocialNetworkConst.NameUrlHasColumnType)
                           .HasMaxLength(SocialNetworkConst.UrlMax)
                           .IsRequired();

            });
    }
}
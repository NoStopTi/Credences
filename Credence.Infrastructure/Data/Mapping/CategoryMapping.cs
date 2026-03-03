
using Credence.Default.DomainContext.Entities.Constants.SalesContext;
using Credence.Domain.SalesContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        EntityBaseMapping.Configure(builder);
        
        //SA_ == Sales
        builder.ToTable("SA_Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
        .IsRequired()
        .HasColumnType("NVARCHAR")
        .HasMaxLength(CategoryConst.TitleMax);

        builder.Property(x => x.Description)
        .HasColumnType("NVARCHAR")
        .HasMaxLength(CategoryConst.DescriptionMax);

        builder.Property(x => x.UserId)
        .IsRequired()
               .HasColumnType("BINARY(16)");

    }
}
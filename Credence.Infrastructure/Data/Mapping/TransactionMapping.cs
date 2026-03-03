using Credence.Default.DomainContext.Entities.Constants.SalesContext;
using Credence.Domain.SalesContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credence.Infrastructure.Data.Mapping;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        EntityBaseMapping.Configure(builder);

        //SA_ == Sales
        builder.ToTable("SA_Transactions");

        builder.Property(x => x.Title)
        .IsRequired()
        .HasColumnType("NVARCHAR")
        .HasMaxLength(TransactionConst.TitleMax);

        builder.Property(x => x.Type)
        .IsRequired()
        .HasColumnType("SMALLINT");

        builder.Property(x => x.Amount)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CreatedAt)
        .IsRequired();

        builder.Property(x => x.PaidOrReceivedAt)
        .IsRequired();

        builder.Property(x => x.UserId)
        .IsRequired()
               .HasColumnType("BINARY(16)");
    }
}
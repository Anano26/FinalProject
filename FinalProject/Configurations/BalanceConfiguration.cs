using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.ToTable(nameof(Balance), "schedule");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.Debt)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Balances)
                .HasForeignKey(x => x.Id);

            builder.HasOne(x => x.Semester)
                .WithMany(x => x.Balances)
                .HasForeignKey(x => x.Id);
            

        }
    }
}

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
                .IsRequired();

            builder.Property(x => x.Debt)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Balances)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FL_Balance_Student");

            builder.HasOne(x => x.Semester);
            

        }
    }
}

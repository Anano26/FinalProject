using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address), "schedule");

            builder.Property(x => x.Address1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Address2)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

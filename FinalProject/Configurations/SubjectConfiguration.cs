using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject", "schedule");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Credit)
                    .IsRequired();
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasMany(x => x.Students)
                    .WithMany(x => x.Subjects);
        }
    }
}

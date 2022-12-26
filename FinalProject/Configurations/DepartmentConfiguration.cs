using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>

    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department), "schedule");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.MaxNumbOfStudents)
                .IsRequired();

            builder.Property(x => x.CurrentAmount)
                .IsRequired();

            builder.HasOne(x => x.Semester);
        }
    }
}

using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher", "schedule");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(x => x.PersonalId)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.HasOne(x => x.Subject)
                    .WithMany(x => x.Teachers)
                    .HasForeignKey(x => x.Id)
                    .HasConstraintName("FK_Teacher_Subject");

            builder.HasOne(x => x.Department)
                    .WithMany(x => x.Teachers)
                    .HasForeignKey(x => x.Id)
                    .HasConstraintName("FK_Teacher_Department");

            builder.HasOne(x => x.Address)
                    .WithOne(x => x.Teacher);
        }
    }
}

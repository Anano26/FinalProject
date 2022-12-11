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

            builder.Property(x => x.LowerBound)
                    .IsRequired();

            builder.HasMany(x => x.Teachers)
                    .WithOne(x => x.Subject)
                    .HasForeignKey(x => x.Id)
                    .HasConstraintName("FK_Subject_Teacher");

            builder.HasMany(x => x.Schedules)
                    .WithOne(x => x.Subject)
                    .HasForeignKey(x => x.Id)
                    .HasConstraintName("FK_Subject_Schedule");

            builder.HasMany(x => x.StudentSubjects)
                    .WithOne(x => x.Subject)
                    .HasForeignKey(x => x.Id)
                    .HasConstraintName("FK_Subject_StudentSubject");
        }
    }
}

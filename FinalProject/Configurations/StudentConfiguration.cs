using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", "schedule");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.PersonalId)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_Student_Department");

           // builder.HasOne(x => x.Semester);

            builder.HasOne(x => x.Address);
              //  .WithOne(x => x.Student);

            builder.HasMany(x => x.StudentSubjects)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_Student_StudentSubjects");

            builder.HasMany(x => x.Balances)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("FK_Student_Balance");
        }
    }
}

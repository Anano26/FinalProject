using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("StudentSubject", "schedule");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Point)
                .IsRequired();

            builder.HasOne(x => x.Student);

            builder.HasOne(x => x.Subject);
        }
    }
}

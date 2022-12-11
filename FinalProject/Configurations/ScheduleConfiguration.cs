using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace FinalProject.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule", "schedule");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.HasOne(x => x.Semester);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.Id)
                .HasForeignKey("FK_Subject_Schedule");
                
            builder.HasOne(x => x.Room);
        }
    }
}

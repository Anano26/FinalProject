﻿// <auto-generated />
using System;
using FinalProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    partial class ScheduleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalProject.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Address", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Balance", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Debt")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Balance", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentAmount")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumbOfStudents")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Department", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<int>("MaxNumberOfStudents")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Room", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Schedule", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableGPA")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Semester", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Student", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.StudentSubject", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StudentSubject", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<int>("LowerBound")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subject", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Teacher", "schedule");
                });

            modelBuilder.Entity("FinalProject.Models.Balance", b =>
                {
                    b.HasOne("FinalProject.Models.Semester", "Semester")
                        .WithMany("Balances")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FL_Balance_Semester");

                    b.HasOne("FinalProject.Models.Student", "Student")
                        .WithMany("Balances")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Student_Balance");

                    b.Navigation("Semester");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.HasOne("FinalProject.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("FinalProject.Models.Schedule", b =>
                {
                    b.HasOne("FinalProject.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("FinalProject.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.HasOne("FinalProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Room");

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FinalProject.Models.Student", b =>
                {
                    b.HasOne("FinalProject.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("FinalProject.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Student_Department");

                    b.Navigation("Address");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("FinalProject.Models.StudentSubject", b =>
                {
                    b.HasOne("FinalProject.Models.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_StudentSubject_Student");

                    b.HasOne("FinalProject.Models.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Subject_StudentSubject");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FinalProject.Models.Teacher", b =>
                {
                    b.HasOne("FinalProject.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("FinalProject.Models.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Teacher_Department");

                    b.HasOne("FinalProject.Models.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Teacher_Subject");

                    b.Navigation("Address");

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("FinalProject.Models.Semester", b =>
                {
                    b.Navigation("Balances");
                });

            modelBuilder.Entity("FinalProject.Models.Student", b =>
                {
                    b.Navigation("Balances");

                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("FinalProject.Models.Subject", b =>
                {
                    b.Navigation("StudentSubjects");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}

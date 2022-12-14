using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class FinalProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "schedule");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    MaxNumberOfStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailableGPA = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LowerBound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxNumbOfStudents = table.Column<int>(type: "int", nullable: false),
                    CurrentAmount = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "schedule",
                        principalTable: "Semester",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    SemesterId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "schedule",
                        principalTable: "Room",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "schedule",
                        principalTable: "Semester",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "schedule",
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "schedule",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "schedule",
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "schedule",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teacher_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "schedule",
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "schedule",
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Debt = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balance_Semester_Id",
                        column: x => x.Id,
                        principalSchema: "schedule",
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Balance_Student_Id",
                        column: x => x.Id,
                        principalSchema: "schedule",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                schema: "schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "schedule",
                        principalTable: "Student",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "schedule",
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_SemesterId",
                schema: "schedule",
                table: "Department",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_RoomId",
                schema: "schedule",
                table: "Schedule",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SemesterId",
                schema: "schedule",
                table: "Schedule",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SubjectId",
                schema: "schedule",
                table: "Schedule",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                schema: "schedule",
                table: "Student",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                schema: "schedule",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                schema: "schedule",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                schema: "schedule",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AddressId",
                schema: "schedule",
                table: "Teacher",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartmentId",
                schema: "schedule",
                table: "Teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectId",
                schema: "schedule",
                table: "Teacher",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "StudentSubject",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "schedule");

            migrationBuilder.DropTable(
                name: "Semester",
                schema: "schedule");
        }
    }
}

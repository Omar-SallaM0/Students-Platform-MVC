using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Students_Education_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseAndExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullMark = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "DeptId", "Duration" },
                values: new object[,]
                {
                    { 1, "OOP", 2, 40 },
                    { 2, "Database & SQL", 3, 36 },
                    { 3, "Laravel Basics", 4, 30 },
                    { 4, "Network Security", 5, 45 },
                    { 5, "HTML & CSS & JS", 7, 50 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CourseId", "Date", "FullMark", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 100, "OOP Final Exam" },
                    { 2, 2, new DateTime(2026, 6, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 50, "SQL Practical Exam" },
                    { 3, 3, new DateTime(2026, 6, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 20, "Laravel Basic Quiz" },
                    { 4, 4, new DateTime(2026, 6, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 100, "Network Security Midterm" },
                    { 5, 5, new DateTime(2026, 6, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), 100, "Front-End Integration Test" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptId",
                table: "Courses",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}

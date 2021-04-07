using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseLearningOutcome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Course = table.Column<string>(type: "TEXT", nullable: true),
                    Instructor = table.Column<string>(type: "TEXT", nullable: true),
                    CourseLearningOutcomeDescription = table.Column<string>(type: "TEXT", nullable: true),
                    TotalStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    CompleteLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    SatisfactoryLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    NotMet = table.Column<int>(type: "INTEGER", nullable: false),
                    NotMeasurable = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLearningOutcome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentOutcome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Course = table.Column<string>(type: "TEXT", nullable: true),
                    Instructor = table.Column<string>(type: "TEXT", nullable: true),
                    StudentOutcomeDescription = table.Column<string>(type: "TEXT", nullable: true),
                    TotalStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    CompleteLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    SatisfactoryLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    NotMet = table.Column<int>(type: "INTEGER", nullable: false),
                    NotMeasurable = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOutcome", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLearningOutcome");

            migrationBuilder.DropTable(
                name: "StudentOutcome");
        }
    }
}

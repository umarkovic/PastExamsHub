using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class ExpandEnttitiesWithIsSoftDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "ExamSolutions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "Exams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "ExamPeriods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "ExamSolutions");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "ExamPeriods");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "Courses");
        }
    }
}

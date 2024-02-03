using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class AddsExamSolutionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTimeUtc",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ExamSolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodType = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskNumber = table.Column<int>(type: "int", nullable: true),
                    DocumentId = table.Column<int>(type: "int", nullable: true),
                    GradeCount = table.Column<int>(type: "int", nullable: false),
                    Uid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSolutions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_DocumentId",
                table: "ExamSolutions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_ExamId",
                table: "ExamSolutions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSolutions_UserId",
                table: "ExamSolutions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamSolutions");

            migrationBuilder.DropColumn(
                name: "CreatedDateTimeUtc",
                table: "Exams");
        }
    }
}

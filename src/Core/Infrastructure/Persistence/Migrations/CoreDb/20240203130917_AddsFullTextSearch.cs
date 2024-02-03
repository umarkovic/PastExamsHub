using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class AddsFullTextSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);


            migrationBuilder.Sql(
                  "CREATE FULLTEXT CATALOG [SearchCatalog] WITH ACCENT_SENSITIVITY = OFF AS DEFAULT",
                  suppressTransaction: true
                      );

            migrationBuilder.Sql(
                "CREATE FULLTEXT STOPLIST [Empty];",
                 suppressTransaction: true);


            migrationBuilder.Sql(
              "CREATE FULLTEXT INDEX ON [dbo].Courses ([Name]) KEY INDEX [PK_Courses] WITH STOPLIST = SYSTEM",
              suppressTransaction: true
          );
            migrationBuilder.Sql(
                "ALTER FULLTEXT INDEX ON [dbo].[Courses] SET STOPLIST = OFF",
                suppressTransaction: true
            );

            migrationBuilder.Sql(
              "CREATE FULLTEXT INDEX ON [dbo].ExamPeriods ([Name]) KEY INDEX [PK_ExamPeriods] WITH STOPLIST = SYSTEM",
              suppressTransaction: true
          );
            migrationBuilder.Sql(
                "ALTER FULLTEXT INDEX ON [dbo].[ExamPeriods] SET STOPLIST = OFF",
                suppressTransaction: true
            );

            migrationBuilder.Sql(
          "CREATE FULLTEXT INDEX ON [dbo].Users ([FullName]) KEY INDEX [PK_Users] WITH STOPLIST = SYSTEM",
          suppressTransaction: true
          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");
        }
    }
}

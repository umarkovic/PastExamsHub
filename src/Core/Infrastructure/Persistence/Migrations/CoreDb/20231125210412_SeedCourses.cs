using Microsoft.EntityFrameworkCore.Migrations;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    public partial class SeedCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "Index", "LastName", "Role", "StudyYear", "Uid" },
                values: new object[] { 2, "profesor@localhost", "Profesor", 1, null, "Elfakovic", 3, null, "profesor" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseType", "ESPB", "LecturerId", "Name", "StudyType", "StudyYear", "Uid" },
                values: new object[,]
                {
                    { 1, 1, 6, 2, "Algoritmi i programiranje", 1, 1, "aip" },
                    { 22, 2, 6, 2, "Teorija grafova", 1, 2, "tg" },
                    { 23, 2, 6, 2, "Verovatnoca i statistika", 1, 2, "statistika" },
                    { 24, 1, 6, 2, "Distribuirani Sistemi", 1, 3, "ds" },
                    { 25, 1, 6, 2, "Engleski jezik 1", 1, 3, "eng1" },
                    { 26, 1, 6, 2, "Engleski jezik 2", 1, 3, "eng2" },
                    { 27, 1, 6, 2, "Informacioni sistemi", 1, 3, "is" },
                    { 28, 1, 6, 2, "Mikroracunarski sistemi", 1, 3, "mkis" },
                    { 21, 1, 6, 2, "Racunarski Sistemi", 1, 2, "rs" },
                    { 29, 1, 6, 2, "Objektno orijentisano projektovanje", 1, 3, "ooproj" },
                    { 31, 1, 6, 2, "Sistemi baza podataka", 1, 3, "sitemibaza" },
                    { 32, 1, 6, 2, "Softversko inzenjerstvo", 1, 3, "softversko" },
                    { 33, 1, 6, 2, "Web programiranje", 1, 3, "webprog" },
                    { 34, 1, 6, 2, "Napredne baze podataka", 1, 4, "npbaze" },
                    { 35, 1, 6, 2, "Paralelni sistemi", 1, 4, "ps" },
                    { 36, 1, 6, 2, "Programski prevodioci", 1, 4, "pprevodioci" },
                    { 37, 1, 6, 2, "Racunarska grafika", 1, 4, "grafika" },
                    { 30, 1, 6, 2, "Racunarske mreze", 1, 3, "mreze" },
                    { 38, 1, 6, 2, "Vestacka inteligencija", 1, 4, "vestacka" },
                    { 20, 1, 6, 2, "Strukture Podataka", 1, 2, "strukture" },
                    { 18, 1, 6, 2, "Objektno orijentisano programiranje", 1, 2, "oop" },
                    { 2, 1, 6, 2, "Elektronske komponente", 1, 1, "elkomp" },
                    { 3, 1, 6, 2, "Fizika", 1, 1, "fizika" },
                    { 4, 1, 3, 2, "Lab praktikum - Fizika", 1, 1, "labfizika" },
                    { 5, 1, 6, 2, "Matematika 1", 1, 1, "mat1" },
                    { 6, 1, 5, 2, "Matematika 2", 1, 1, "mat2" },
                    { 7, 1, 6, 2, "Osnovi elektrotehnike 1", 1, 1, "oe1" },
                    { 8, 1, 6, 2, "Osnovi elektrotehnike 2", 1, 1, "oe2" },
                    { 19, 1, 6, 2, "Programski jezici", 1, 2, "pj" },
                    { 9, 1, 3, 2, "Uvod u elektroniku", 1, 1, "uue" },
                    { 11, 1, 3, 2, "Uvod u racunarstvo", 1, 1, "uur" },
                    { 12, 1, 6, 2, "Arhitektura i organizacija racunara", 1, 2, "aor" },
                    { 13, 1, 6, 2, "Baze Podataka", 1, 2, "baze" },
                    { 14, 1, 5, 2, "Digitalna elektronika", 1, 2, "digitalelekt" },
                    { 15, 1, 5, 2, "Diskretna matematika", 1, 2, "diskrmat" },
                    { 16, 2, 5, 2, "Logicko projektovanje", 1, 2, "logproj" },
                    { 17, 2, 6, 2, "Matematicki metodi u racunarstvu", 1, 2, "mmur" },
                    { 10, 1, 3, 2, "Uvod u inzenjerstvo", 1, 1, "uui" },
                    { 39, 1, 6, 2, "Zastita informacija", 1, 4, "zastita" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

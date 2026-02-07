using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetDiary.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedVisitReasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VisitReasons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "General Checkup" },
                    { 2, "Illness" },
                    { 3, "Vaccination" },
                    { 4, "Surgery" },
                    { 5, "Injury" },
                    { 6, "Dental Care" },
                    { 7, "Parasite Treatment" },
                    { 8, "Emergency" },
                    { 9, "Follow Up" },
                    { 10, "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VisitReasons",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}

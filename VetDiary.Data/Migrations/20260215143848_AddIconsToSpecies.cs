using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetDiary.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIconsToSpecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: "🐶");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "Icon",
                value: "🐱");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                column: "Icon",
                value: "🐰");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4,
                column: "Icon",
                value: "🐹");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5,
                column: "Icon",
                value: "🐹");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 6,
                column: "Icon",
                value: "🦜");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 7,
                column: "Icon",
                value: "🦦");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 8,
                column: "Icon",
                value: "🐦");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 9,
                column: "Icon",
                value: "🐢");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 10,
                column: "Icon",
                value: "🐍");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 11,
                column: "Icon",
                value: "🦎");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "🐸", "Frog" });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 13,
                column: "Icon",
                value: "🐴");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 14,
                column: "Icon",
                value: "🐎");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 15,
                column: "Icon",
                value: "🐑");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 16,
                column: "Icon",
                value: "🐐");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 17,
                column: "Icon",
                value: "🐎");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 18,
                column: "Icon",
                value: "🐷");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 19,
                column: "Icon",
                value: "🐤");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 20,
                column: "Icon",
                value: "🦃");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 21,
                column: "Icon",
                value: "🐟");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 22,
                column: "Icon",
                value: "🐭");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 23,
                column: "Icon",
                value: "🐾");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 24,
                column: "Icon",
                value: "🕊️");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 25,
                column: "Icon",
                value: "🐲");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 26,
                column: "Icon",
                value: "🦄");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Species");

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Snake");
        }
    }
}

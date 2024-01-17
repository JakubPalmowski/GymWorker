using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedImageUriOptionalFieldToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 23,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 24,
                column: "ImageUri",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 25,
                column: "ImageUri",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Users");
        }
    }
}

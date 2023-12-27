using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAddressFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_Id_Address",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id_Address",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Address",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 2,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 3,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 4,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 5,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 6,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 7,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 8,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 9,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 10,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 11,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 12,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 13,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 14,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 15,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 16,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 17,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 18,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 19,
                column: "Id_Address",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 20,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 21,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 22,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 23,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 24,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 25,
                column: "Id_Address",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Address",
                table: "Users",
                column: "Id_Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_Id_Address",
                table: "Users",
                column: "Id_Address",
                principalTable: "Addresses",
                principalColumn: "Id_Address",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

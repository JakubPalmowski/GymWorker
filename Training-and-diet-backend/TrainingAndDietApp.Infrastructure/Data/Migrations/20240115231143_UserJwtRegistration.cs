using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserJwtRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailValidated",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmationToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpirationDate",
                table: "Users",
                type: "timestamp",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 23,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 24,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 25,
                columns: new[] { "EmailConfirmationToken", "HashedPassword", "RefreshToken", "RefreshTokenExpirationDate" },
                values: new object[] { null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmationToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpirationDate",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "EmailValidated",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 23,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 24,
                column: "EmailValidated",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 25,
                column: "EmailValidated",
                value: true);
        }
    }
}

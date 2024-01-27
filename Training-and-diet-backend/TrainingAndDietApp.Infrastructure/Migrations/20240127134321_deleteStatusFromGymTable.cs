using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteStatusFromGymTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Gyms");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Gyms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 1,
                column: "IsAccepted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                column: "IsAccepted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                column: "IsAccepted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Gyms");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Gyms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 1,
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                column: "Status",
                value: "Active");
        }
    }
}

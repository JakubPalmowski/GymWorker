using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAndAddedByColumnToGymTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Gyms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "AddedBy", "Status" },
                values: new object[] { 0, "Active" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                columns: new[] { "AddedBy", "Status" },
                values: new object[] { 0, "Active" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                columns: new[] { "AddedBy", "Status" },
                values: new object[] { 0, "Active" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Gyms");
        }
    }
}

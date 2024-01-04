using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedCustomNameFieldToTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                table: "Training_plans",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 1,
                column: "CustomName",
                value: "Plan treningowy dla mirka");

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 2,
                column: "CustomName",
                value: "Plan treningowy dla jacka");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomName",
                table: "Training_plans");
        }
    }
}

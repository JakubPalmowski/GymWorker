using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDurationToTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Plan_Duration",
                table: "Training_plans",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1,
                column: "Plan_Duration",
                value: null);

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 2,
                column: "Plan_Duration",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan_Duration",
                table: "Training_plans");
        }
    }
}

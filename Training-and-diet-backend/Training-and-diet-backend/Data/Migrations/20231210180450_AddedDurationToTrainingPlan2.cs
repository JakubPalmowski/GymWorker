using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDurationToTrainingPlan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1,
                column: "Plan_Duration",
                value: 21);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1,
                column: "Plan_Duration",
                value: null);
        }
    }
}

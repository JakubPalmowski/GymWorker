using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterPicesColumnsNamesInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainingPlanPriceTo",
                table: "Users",
                newName: "Training_plan_price_to");

            migrationBuilder.RenameColumn(
                name: "TrainingPlanPriceFrom",
                table: "Users",
                newName: "Training_plan_price_from");

            migrationBuilder.RenameColumn(
                name: "PersonalTrainingPriceTo",
                table: "Users",
                newName: "Personal_training_price_to");

            migrationBuilder.RenameColumn(
                name: "PersonalTrainingPriceFrom",
                table: "Users",
                newName: "Personal_training_price_from");

            migrationBuilder.RenameColumn(
                name: "DietPriceTo",
                table: "Users",
                newName: "Diet_price_to");

            migrationBuilder.RenameColumn(
                name: "DietPriceFrom",
                table: "Users",
                newName: "Diet_price_from");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Training_plan_price_to",
                table: "Users",
                newName: "TrainingPlanPriceTo");

            migrationBuilder.RenameColumn(
                name: "Training_plan_price_from",
                table: "Users",
                newName: "TrainingPlanPriceFrom");

            migrationBuilder.RenameColumn(
                name: "Personal_training_price_to",
                table: "Users",
                newName: "PersonalTrainingPriceTo");

            migrationBuilder.RenameColumn(
                name: "Personal_training_price_from",
                table: "Users",
                newName: "PersonalTrainingPriceFrom");

            migrationBuilder.RenameColumn(
                name: "Diet_price_to",
                table: "Users",
                newName: "DietPriceTo");

            migrationBuilder.RenameColumn(
                name: "Diet_price_from",
                table: "Users",
                newName: "DietPriceFrom");
        }
    }
}

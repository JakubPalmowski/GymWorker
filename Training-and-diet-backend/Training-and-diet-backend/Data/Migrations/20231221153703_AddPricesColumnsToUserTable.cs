using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPricesColumnsToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DietPriceFrom",
                table: "Users",
                type: "numeric(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DietPriceTo",
                table: "Users",
                type: "numeric(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PersonalTrainingPriceFrom",
                table: "Users",
                type: "numeric(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PersonalTrainingPriceTo",
                table: "Users",
                type: "numeric(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TrainingPlanPriceFrom",
                table: "Users",
                type: "numeric(4,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TrainingPlanPriceTo",
                table: "Users",
                type: "numeric(4,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 2,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 3,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 4,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 5,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 6,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 7,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 8,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 9,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 10,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 11,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 12,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 13,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 14,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 15,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 16,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 17,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 18,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 19,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 20,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 21,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 22,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 23,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 24,
                columns: new[] { "DietPriceFrom", "DietPriceTo", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "TrainingPlanPriceFrom", "TrainingPlanPriceTo" },
                values: new object[] { null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DietPriceFrom",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DietPriceTo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonalTrainingPriceFrom",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonalTrainingPriceTo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainingPlanPriceFrom",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainingPlanPriceTo",
                table: "Users");
        }
    }
}

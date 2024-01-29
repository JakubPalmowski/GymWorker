using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteCompoundKeyFromMealDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal_Diets",
                table: "Meal_Diets");

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal_Diets",
                table: "Meal_Diets",
                column: "IdMealDiet");

            migrationBuilder.InsertData(
                table: "Meal_Diets",
                columns: new[] { "IdMealDiet", "Comments", "DayOfWeek", "HourOfMeal", "IdDiet", "IdMeal" },
                values: new object[,]
                {
                    { 1, "Jedz sobie", 1, "12:00", 1, 1 },
                    { 2, null, 2, "12:00", 1, 2 },
                    { 3, null, 1, "12:00", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Diets_IdMeal",
                table: "Meal_Diets",
                column: "IdMeal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal_Diets",
                table: "Meal_Diets");

            migrationBuilder.DropIndex(
                name: "IX_Meal_Diets_IdMeal",
                table: "Meal_Diets");

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumn: "IdMealDiet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumn: "IdMealDiet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumn: "IdMealDiet",
                keyValue: 3);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal_Diets",
                table: "Meal_Diets",
                columns: new[] { "IdMeal", "IdDiet" });

            migrationBuilder.InsertData(
                table: "Meal_Diets",
                columns: new[] { "IdDiet", "IdMeal", "Comments", "DayOfWeek", "HourOfMeal", "IdMealDiet" },
                values: new object[,]
                {
                    { 1, 1, "Jedz sobie", 1, "12:00", 1 },
                    { 2, 1, null, 1, "12:00", 3 },
                    { 1, 2, null, 2, "12:00", 2 }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeDietAndMealsDietTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Meal_Diets");

            migrationBuilder.DropColumn(
                name: "DietDuration",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Diets");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Meal_Diets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HourOfMeal",
                table: "Meal_Diets",
                type: "varchar(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                table: "Diets",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Diets",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWeeks",
                table: "Diets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Diets",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 1,
                columns: new[] { "CustomName", "Name", "NumberOfWeeks", "Type" },
                values: new object[] { "Plan treningowy dla mirka", "Plan treningowy dla początkujących", 4, "Siłowy" });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 2,
                columns: new[] { "CustomName", "Name", "NumberOfWeeks", "Type" },
                values: new object[] { "Plan treningowy dla jacka", "Plan treningowy na odchudzanie", 4, "Cardio" });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 3,
                columns: new[] { "CustomName", "Name", "NumberOfWeeks", "Type" },
                values: new object[] { "Plan treningowy dla Wlodara", "Plan treningowy dla początkujących", 4, "Siłowy" });

            migrationBuilder.UpdateData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Comments", "DayOfWeek", "HourOfMeal" },
                values: new object[] { "Jedz sobie", 1, "12:00" });

            migrationBuilder.UpdateData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "DayOfWeek", "HourOfMeal" },
                values: new object[] { 1, "12:00" });

            migrationBuilder.UpdateData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "DayOfWeek", "HourOfMeal" },
                values: new object[] { 2, "12:00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Meal_Diets");

            migrationBuilder.DropColumn(
                name: "HourOfMeal",
                table: "Meal_Diets");

            migrationBuilder.DropColumn(
                name: "CustomName",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "NumberOfWeeks",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Diets");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Meal_Diets",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DietDuration",
                table: "Diets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Diets",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 1,
                columns: new[] { "DietDuration", "EndDate" },
                values: new object[] { "1", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 2,
                columns: new[] { "DietDuration", "EndDate" },
                values: new object[] { "30", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 3,
                columns: new[] { "DietDuration", "EndDate" },
                values: new object[] { "30", new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Comments", "Date" },
                values: new object[] { null, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 2, 1 },
                column: "Date",
                value: new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Meal_Diets",
                keyColumns: new[] { "IdDiet", "IdMeal" },
                keyValues: new object[] { 1, 2 },
                column: "Date",
                value: new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class TraineeExercisesPropertyChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Trainee_exercises");

            migrationBuilder.AlterColumn<string>(
                name: "RepetitionsNumber",
                table: "Trainee_exercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Trainee_exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 1,
                columns: new[] { "DayOfWeek", "RepetitionsNumber" },
                values: new object[] { 5, "12" });

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 2,
                columns: new[] { "DayOfWeek", "RepetitionsNumber" },
                values: new object[] { 1, "10" });

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 3,
                columns: new[] { "DayOfWeek", "RepetitionsNumber" },
                values: new object[] { 2, "15" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Trainee_exercises");

            migrationBuilder.AlterColumn<int>(
                name: "RepetitionsNumber",
                table: "Trainee_exercises",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Trainee_exercises",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 1,
                columns: new[] { "Date", "RepetitionsNumber" },
                values: new object[] { new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 });

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 2,
                columns: new[] { "Date", "RepetitionsNumber" },
                values: new object[] { new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 3,
                columns: new[] { "Date", "RepetitionsNumber" },
                values: new object[] { new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 });
        }
    }
}

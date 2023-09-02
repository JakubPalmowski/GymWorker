using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTraineeExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exercise_duration",
                table: "Trainee_exercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Exercise_duration",
                table: "Trainee_exercises",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "Id_Trainee_exercise",
                keyValue: 1,
                column: "Exercise_duration",
                value: new TimeSpan(0, 0, 30, 0, 0));

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "Id_Trainee_exercise",
                keyValue: 2,
                column: "Exercise_duration",
                value: new TimeSpan(0, 0, 35, 0, 0));

            migrationBuilder.UpdateData(
                table: "Trainee_exercises",
                keyColumn: "Id_Trainee_exercise",
                keyValue: 3,
                column: "Exercise_duration",
                value: new TimeSpan(0, 0, 25, 0, 0));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTrainingPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan_duration",
                table: "Training_plans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Plan_duration",
                table: "Training_plans",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1,
                column: "Plan_duration",
                value: new TimeSpan(21, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 2,
                column: "Plan_duration",
                value: new TimeSpan(31, 0, 0, 0, 0));
        }
    }
}

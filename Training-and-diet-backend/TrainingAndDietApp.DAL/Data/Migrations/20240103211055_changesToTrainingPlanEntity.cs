using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class changesToTrainingPlanEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Training_plans");

            migrationBuilder.DropColumn(
                name: "PlanDuration",
                table: "Training_plans");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWeeks",
                table: "Training_plans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 1,
                column: "NumberOfWeeks",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 2,
                column: "NumberOfWeeks",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfWeeks",
                table: "Training_plans");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Training_plans",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlanDuration",
                table: "Training_plans",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 1,
                columns: new[] { "EndDate", "PlanDuration" },
                values: new object[] { new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 2,
                columns: new[] { "EndDate", "PlanDuration" },
                values: new object[] { new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}

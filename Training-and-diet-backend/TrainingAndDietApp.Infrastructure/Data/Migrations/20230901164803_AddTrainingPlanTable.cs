using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainingPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Training_plan",
                table: "Trainee_exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Training_plan",
                columns: table => new
                {
                    Id_Training_plan = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    Start_date = table.Column<DateTime>(type: "Date", nullable: false),
                    End_date = table.Column<DateTime>(type: "Date", nullable: false),
                    Plan_duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_plan", x => x.Id_Training_plan);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_exercises_Id_Training_plan",
                table: "Trainee_exercises",
                column: "Id_Training_plan");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Training_plan_Id_Training_plan",
                table: "Trainee_exercises",
                column: "Id_Training_plan",
                principalTable: "Training_plan",
                principalColumn: "Id_Training_plan",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Training_plan_Id_Training_plan",
                table: "Trainee_exercises");

            migrationBuilder.DropTable(
                name: "Training_plan");

            migrationBuilder.DropIndex(
                name: "IX_Trainee_exercises_Id_Training_plan",
                table: "Trainee_exercises");

            migrationBuilder.DropColumn(
                name: "Id_Training_plan",
                table: "Trainee_exercises");
        }
    }
}

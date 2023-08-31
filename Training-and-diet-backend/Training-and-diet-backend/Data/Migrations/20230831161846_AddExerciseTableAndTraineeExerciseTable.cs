using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseTableAndTraineeExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id_Exercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Exercise_steps = table.Column<string>(type: "jsonb", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id_Exercise);
                });

            migrationBuilder.CreateTable(
                name: "Trainee_exercises",
                columns: table => new
                {
                    Id_Trainee_exercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Series_number = table.Column<int>(type: "integer", nullable: false),
                    Repetitions_number = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Exercise_duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Id_Exercise = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee_exercises", x => x.Id_Trainee_exercise);
                    table.ForeignKey(
                        name: "FK_Trainee_exercises_Exercises_Id_Exercise",
                        column: x => x.Id_Exercise,
                        principalTable: "Exercises",
                        principalColumn: "Id_Exercise",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_exercises_Id_Exercise",
                table: "Trainee_exercises",
                column: "Id_Exercise");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainee_exercises");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}

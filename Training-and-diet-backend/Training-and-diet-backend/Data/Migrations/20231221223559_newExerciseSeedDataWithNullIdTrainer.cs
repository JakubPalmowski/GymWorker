using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class newExerciseSeedDataWithNullIdTrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id_Exercise", "Details", "Exercise_steps", "Id_Trainer", "Image", "Name" },
                values: new object[,]
                {
                    { 14, "Ćwiczenie wzmacniające mięśnie nóg i pośladków", "1. Stań w rozkroku i ugnij nogi w kolanach", null, null, "Przysiady" },
                    { 15, "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.", "W podporze przodem ugnij ręcę w łokciach", null, null, "Pompki" },
                    { 16, "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.", "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.", null, null, "Boczny plank" },
                    { 17, "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.", "W pozycji planku na przedramionach, unieś na przemian każdą nogę.", null, null, "Plank z podnoszeniem nóg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 17);
        }
    }
}

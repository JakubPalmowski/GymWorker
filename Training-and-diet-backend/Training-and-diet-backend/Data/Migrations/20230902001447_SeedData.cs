using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Age", "Email", "Email_validated", "Height", "Last_name", "Name", "Phone_number", "Role", "Sex", "Weight" },
                values: new object[,]
                {
                    { 1, null, "michal@gmail.com", true, null, "Emczyk", "Michał", "48777888777", 3, "Male", null },
                    { 2, null, "anna@gmail.com", true, null, "Kowalska", "Anna", "48666778888", 2, "Female", null },
                    { 3, null, "john@gmail.com", true, null, "Doe", "John", "48555667777", 2, "Male", null }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id_Exercise", "Details", "Exercise_steps", "Id_Trainer", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.", "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]", 1, null, "Pompki" },
                    { 2, "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.", "[{\"Step\": 1, \"Description\": \"Stań prosto, nogi ustawione na szerokość bioder.\"}, {\"Step\": 2, \"Description\": \"Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło.\"}, {\"Step\": 3, \"Description\": \"Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.\"}]", 1, null, "Przysiady" },
                    { 3, "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.", "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]", 1, null, "Plank" }
                });

            migrationBuilder.InsertData(
                table: "Training_plans",
                columns: new[] { "Id_Training_plan", "End_date", "Id_Pupil", "Id_Trainer", "Name", "Plan_duration", "Start_date", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Plan treningowy dla początkujących", new TimeSpan(21, 0, 0, 0, 0), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siłowy" },
                    { 2, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Plan treningowy na odchudzanie", new TimeSpan(31, 0, 0, 0, 0), new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "Trainee_exercises",
                columns: new[] { "Id_Trainee_exercise", "Comments", "Date", "Exercise_duration", "Id_Exercise", "Id_Training_plan", "Repetitions_number", "Series_number" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 30, 0, 0), 1, 1, 12, 3 },
                    { 2, null, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 35, 0, 0), 2, 1, 10, 4 },
                    { 3, null, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 25, 0, 0), 3, 2, 15, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainee_exercises",
                keyColumn: "Id_Trainee_exercise",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainee_exercises",
                keyColumn: "Id_Trainee_exercise",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainee_exercises",
                keyColumn: "Id_Trainee_exercise",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 2);
        }
    }
}

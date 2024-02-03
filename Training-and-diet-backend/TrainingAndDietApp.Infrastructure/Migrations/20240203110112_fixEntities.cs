using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainee_exercises",
                keyColumn: "IdTraineeExercise",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "IdExercise",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Meals");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(254)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Trainee_exercises",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdPupil",
                table: "Pupil_mentors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "IdMentor",
                table: "Pupil_mentors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "PrepareSteps",
                table: "Meals",
                type: "varchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "Meals",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gyms",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseSteps",
                table: "Exercises",
                type: "varchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Exercises",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Certificates",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 23, 7 },
                column: "Content",
                value: "zne, a jednocześnie przyjazne i motywująmocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(254)");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Trainee_exercises",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdPupil",
                table: "Pupil_mentors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "IdMentor",
                table: "Pupil_mentors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "PrepareSteps",
                table: "Meals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "Meals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Meals",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gyms",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseSteps",
                table: "Exercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Exercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Certificates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Name" },
                values: new object[,]
                {
                    { 1, "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.", "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]", 1, "Pompki" },
                    { 2, "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.", "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2: Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.", 1, "Przysiady" },
                    { 3, "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.", "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]", null, "Plank" },
                    { 14, "Ćwiczenie wzmacniające mięśnie nóg i pośladków", "1. Stań w rozkroku i ugnij nogi w kolanach", null, "Przysiady" },
                    { 15, "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.", "W podporze przodem ugnij ręcę w łokciach", null, "Pompki" },
                    { 16, "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.", "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.", null, "Boczny plank" },
                    { 17, "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.", "W pozycji planku na przedramionach, unieś na przemian każdą nogę.", null, "Plank z podnoszeniem nóg" }
                });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "IdMeal",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "IdMeal",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "IdMeal",
                keyValue: 3,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 23, 7 },
                column: "Content",
                value: "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.");

            migrationBuilder.InsertData(
                table: "Trainee_exercises",
                columns: new[] { "IdTraineeExercise", "Comments", "DayOfWeek", "IdExercise", "IdTrainingPlan", "RepetitionsNumber", "SeriesNumber" },
                values: new object[,]
                {
                    { 1, null, 5, 1, 1, "12", 3 },
                    { 2, null, 1, 2, 1, "10", 4 },
                    { 3, null, 2, 3, 2, "15", 2 }
                });
        }
    }
}

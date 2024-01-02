using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class smallNameFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal_Diets");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Pupil_mentors");

            migrationBuilder.DropTable(
                name: "Trainee_exercises");

            migrationBuilder.DropTable(
                name: "Trainer_Gyms");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Training_plans");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Street = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "char(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gym",
                columns: table => new
                {
                    IdGym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAddress = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gym", x => x.IdGym);
                    table.ForeignKey(
                        name: "FK_Gym_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "char(11)", nullable: false),
                    EmailValidated = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(3,2)", nullable: true),
                    Height = table.Column<decimal>(type: "numeric(3,2)", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Sex = table.Column<string>(type: "varchar(10)", nullable: false),
                    Bio = table.Column<string>(type: "varchar(500)", nullable: false),
                    TrainingPlanPriceFrom = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    TrainingPlanPriceTo = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    PersonalTrainingPriceFrom = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    PersonalTrainingPriceTo = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    DietPriceFrom = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    DietPriceTo = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    IdRole = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    IdDiet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDietician = table.Column<int>(type: "integer", nullable: false),
                    IdPupil = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DietDuration = table.Column<string>(type: "text", nullable: false),
                    TotalKcal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.IdDiet);
                    table.ForeignKey(
                        name: "FK_Diet_User_IdDietician",
                        column: x => x.IdDietician,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diet_User_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    IdExercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    ExerciseSteps = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    IdTrainer = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.IdExercise);
                    table.ForeignKey(
                        name: "FK_Exercise_User_IdTrainer",
                        column: x => x.IdTrainer,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    IdMeal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDietician = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    PrepareSteps = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Kcal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.IdMeal);
                    table.ForeignKey(
                        name: "FK_Meal_User_IdDietician",
                        column: x => x.IdDietician,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinion",
                columns: table => new
                {
                    IdPupil = table.Column<int>(type: "integer", nullable: false),
                    IdMentor = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "varchar(1000)", nullable: false),
                    OpinionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinion", x => new { x.IdPupil, x.IdMentor });
                    table.ForeignKey(
                        name: "FK_Opinion_User_IdMentor",
                        column: x => x.IdMentor,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinion_User_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PupilMentor",
                columns: table => new
                {
                    IdMentor = table.Column<int>(type: "integer", nullable: false),
                    IdPupil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilMentor", x => new { x.IdMentor, x.IdPupil });
                    table.ForeignKey(
                        name: "FK_PupilMentor_User_IdMentor",
                        column: x => x.IdMentor,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PupilMentor_User_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerGym",
                columns: table => new
                {
                    IdTrainerGym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdGym = table.Column<int>(type: "integer", nullable: false),
                    IdTrainer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerGym", x => new { x.IdGym, x.IdTrainer });
                    table.ForeignKey(
                        name: "FK_TrainerGym_Gym_IdGym",
                        column: x => x.IdGym,
                        principalTable: "Gym",
                        principalColumn: "IdGym",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerGym_User_IdTrainer",
                        column: x => x.IdTrainer,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    IdTrainingPlan = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PlanDuration = table.Column<int>(type: "integer", nullable: true),
                    IdTrainer = table.Column<int>(type: "integer", nullable: false),
                    IdPupil = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.IdTrainingPlan);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_User_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "User",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_TrainingPlan_User_IdTrainer",
                        column: x => x.IdTrainer,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealDiet",
                columns: table => new
                {
                    IdMealDiet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMeal = table.Column<int>(type: "integer", nullable: false),
                    IdDiet = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Comments = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDiet", x => new { x.IdMeal, x.IdDiet });
                    table.ForeignKey(
                        name: "FK_MealDiet_Diet_IdDiet",
                        column: x => x.IdDiet,
                        principalTable: "Diet",
                        principalColumn: "IdDiet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealDiet_Meal_IdMeal",
                        column: x => x.IdMeal,
                        principalTable: "Meal",
                        principalColumn: "IdMeal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeExercise",
                columns: table => new
                {
                    IdTraineeExercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesNumber = table.Column<int>(type: "integer", nullable: false),
                    RepetitionsNumber = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    IdExercise = table.Column<int>(type: "integer", nullable: false),
                    IdTrainingPlan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeExercise", x => x.IdTraineeExercise);
                    table.ForeignKey(
                        name: "FK_TraineeExercise_Exercise_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "IdExercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeExercise_TrainingPlan_IdTrainingPlan",
                        column: x => x.IdTrainingPlan,
                        principalTable: "TrainingPlan",
                        principalColumn: "IdTrainingPlan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "IdAddress", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "02-222", "Zlota" },
                    { 2, "Białystok", "02-324", "Kryształowa" },
                    { 3, "Kraków", "02-421", "Mendelejewa" }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Image", "Name" },
                values: new object[,]
                {
                    { 3, "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.", "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]", null, null, "Plank" },
                    { 14, "Ćwiczenie wzmacniające mięśnie nóg i pośladków", "1. Stań w rozkroku i ugnij nogi w kolanach", null, null, "Przysiady" },
                    { 15, "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.", "W podporze przodem ugnij ręcę w łokciach", null, null, "Pompki" },
                    { 16, "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.", "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.", null, null, "Boczny plank" },
                    { 17, "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.", "W pozycji planku na przedramionach, unieś na przemian każdą nogę.", null, null, "Plank z podnoszeniem nóg" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Pupil" },
                    { 3, "Trainer" },
                    { 4, "Dietician" },
                    { 5, "Dietician-Trainer" }
                });

            migrationBuilder.InsertData(
                table: "Gym",
                columns: new[] { "IdGym", "IdAddress", "Name" },
                values: new object[,]
                {
                    { 1, 1, "GymEntity1" },
                    { 2, 2, "GymEntity2" },
                    { 3, 3, "GymEntity3" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "IdUser", "Age", "Bio", "DietPriceFrom", "DietPriceTo", "Email", "EmailValidated", "Height", "IdRole", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo", "Weight" },
                values: new object[,]
                {
                    { 1, null, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, "michal@gmail.com", true, null, 1, "Emczyk", "Michał", null, null, "48777888777", "Male", null, null, null },
                    { 2, null, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, "anna@gmail.com", true, null, 2, "Kowalska", "Anna", null, null, "48666778888", "Female", null, null, null },
                    { 3, null, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, "john@gmail.com", true, null, 3, "Doe", "John", null, null, "48555667777", "Male", null, null, null },
                    { 4, null, "Hi, I'm Charlie. Let's stay active and have fun!", null, null, "charlie@gmail.com", true, null, 3, "Brown", "Charlie", null, null, "48554567890", "Male", null, null, null },
                    { 5, null, "Hello, I'm Diana. Fitness is my passion!", null, null, "diana@gmail.com", true, null, 3, "Miller", "Diana", null, null, "48555678901", "Female", null, null, null },
                    { 6, null, "Hi, I'm Frank. Let's achieve our fitness goals together!", null, null, "frank@gmail.com", true, null, 3, "Davis", "Frank", null, null, "48556789012", "Male", null, null, null },
                    { 7, null, "Hello, I'm Grace. Fitness is my lifestyle!", null, null, "grace@gmail.com", true, null, 3, "Anderson", "Grace", null, null, "48557890123", "Female", null, null, null },
                    { 8, null, "Hey, I'm Harry. Let's push our limits in every workout!", null, null, "harry@gmail.com", true, null, 3, "Moore", "Harry", null, null, "48558901234", "Male", null, null, null },
                    { 9, null, "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!", null, null, "ivy@gmail.com", true, null, 3, "Turner", "Ivy", null, null, "48559012345", "Female", null, null, null },
                    { 10, null, "Hello, I'm Jack. Let's make every workout count!", null, null, "jack@gmail.com", true, null, 3, "White", "Jack", null, null, "48550123456", "Male", null, null, null },
                    { 11, null, "Hi, I'm Kelly. Fitness is the key to a healthy life!", null, null, "kelly@gmail.com", true, null, 3, "Martin", "Kelly", null, null, "48551234567", "Female", null, null, null },
                    { 12, null, "Hey, I'm Leo. Let's crush our fitness goals!", null, null, "leo@gmail.com", true, null, 3, "Baker", "Leo", null, null, "48552345678", "Male", null, null, null },
                    { 13, null, "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!", null, null, "mia@gmail.com", true, null, 3, "Collins", "Mia", null, null, "48553456789", "Female", null, null, null },
                    { 14, null, "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!", null, null, "nathan@gmail.com", true, null, 3, "Ward", "Nathan", null, null, "48554567890", "Male", null, null, null },
                    { 15, null, "Hey, I'm Olivia. Fitness enthusiast and advocate!", null, null, "olivia@gmail.com", true, null, 3, "Perry", "Olivia", null, null, "48555678901", "Female", null, null, null },
                    { 16, null, "Hello, I'm Peter. Let's make fitness a fun journey!", null, null, "peter@gmail.com", true, null, 3, "Cooper", "Peter", null, null, "48556789012", "Male", null, null, null },
                    { 17, null, "Hi, I'm Quinn. Fitness is my daily dose of happiness!", null, null, "quinn@gmail.com", true, null, 3, "Barnes", "Quinn", null, null, "48557890123", "Female", null, null, null },
                    { 18, null, "Hey, I'm Ryan. Fitness is the key to a balanced life!", null, null, "ryan@gmail.com", true, null, 3, "Fisher", "Ryan", null, null, "48558901234", "Male", null, null, null },
                    { 19, null, "Hello, I'm Sophie. Let's stay fit and fabulous!", null, null, "sophie@gmail.com", true, null, 3, "Turner", "Sophie", null, null, "48559012345", "Female", null, null, null },
                    { 20, null, "Hi, I'm Tom. Fitness is my lifestyle choice!", null, null, "tom@gmail.com", true, null, 3, "Harris", "Tom", null, null, "48550123456", "Male", null, null, null },
                    { 21, null, "Hi, I'm Filip. Fitness is my hobby!", null, null, "filipwgmail.com", true, null, 4, "W", "Filip", null, null, "48550123456", "Male", null, null, null },
                    { 22, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 3, "test", "test", null, null, "48550123456", "Male", null, null, null },
                    { 23, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 3, "test", "test", null, null, "48550123456", "Male", null, null, null },
                    { 24, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 3, "test", "test", null, null, "48550123456", "Male", null, null, null },
                    { 25, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 5, "test", "Dietician-Trainer", null, null, "48550123456", "Male", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "IdDiet", "DietDuration", "EndDate", "IdDietician", "IdPupil", "StartDate", "TotalKcal" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000 },
                    { 2, "30", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000 },
                    { 3, "30", new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500 }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.", "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]", 1, null, "Pompki" },
                    { 2, "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.", "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2: Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.", 1, null, "Przysiady" }
                });

            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "IdMeal", "IdDietician", "Image", "Ingredients", "Kcal", "Name", "PrepareSteps" },
                values: new object[,]
                {
                    { 1, 1, null, "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }", "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }", "Placki ziemniaczane", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 2, 1, null, "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }", "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }", "Owsianka", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 3, 2, null, "{\"ingredient1\": \"szynka\", \"ingredient2\": \"chleb\", \"ingredient3\":  \"masło\" }", "{\"kcal\": \"700\", \"Białko\": \"30\", \"Węglowodany\":  \"200\" , \"Tłuszcze\": \"26\" }", "Kanapki z szynką", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" }
                });

            migrationBuilder.InsertData(
                table: "Opinion",
                columns: new[] { "IdMentor", "IdPupil", "Content", "OpinionDate", "Rate" },
                values: new object[,]
                {
                    { 1, 2, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 1, 3, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 22, 5, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m },
                    { 22, 6, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 23, 7, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 23, 8, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m }
                });

            migrationBuilder.InsertData(
                table: "PupilMentor",
                columns: new[] { "IdMentor", "IdPupil" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "TrainerGym",
                columns: new[] { "IdGym", "IdTrainer" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TrainingPlan",
                columns: new[] { "IdTrainingPlan", "EndDate", "IdPupil", "IdTrainer", "Name", "PlanDuration", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Plan treningowy dla początkujących", null, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siłowy" },
                    { 2, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Plan treningowy na odchudzanie", null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "MealDiet",
                columns: new[] { "IdDiet", "IdMeal", "Comments", "Date", "IdMealDiet" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, null, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, 2, null, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "TraineeExercise",
                columns: new[] { "IdTraineeExercise", "Comments", "Date", "IdExercise", "IdTrainingPlan", "RepetitionsNumber", "SeriesNumber" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 12, 3 },
                    { 2, null, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 10, 4 },
                    { 3, null, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 15, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diet_IdDietician",
                table: "Diet",
                column: "IdDietician");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_IdPupil",
                table: "Diet",
                column: "IdPupil");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdTrainer",
                table: "Exercise",
                column: "IdTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Gym_IdAddress",
                table: "Gym",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_IdDietician",
                table: "Meal",
                column: "IdDietician");

            migrationBuilder.CreateIndex(
                name: "IX_MealDiet_IdDiet",
                table: "MealDiet",
                column: "IdDiet");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_IdMentor",
                table: "Opinion",
                column: "IdMentor");

            migrationBuilder.CreateIndex(
                name: "IX_PupilMentor_IdPupil",
                table: "PupilMentor",
                column: "IdPupil");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeExercise_IdExercise",
                table: "TraineeExercise",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeExercise_IdTrainingPlan",
                table: "TraineeExercise",
                column: "IdTrainingPlan");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerGym_IdTrainer",
                table: "TrainerGym",
                column: "IdTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_IdPupil",
                table: "TrainingPlan",
                column: "IdPupil");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_IdTrainer",
                table: "TrainingPlan",
                column: "IdTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealDiet");

            migrationBuilder.DropTable(
                name: "Opinion");

            migrationBuilder.DropTable(
                name: "PupilMentor");

            migrationBuilder.DropTable(
                name: "TraineeExercise");

            migrationBuilder.DropTable(
                name: "TrainerGym");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TrainingPlan");

            migrationBuilder.DropTable(
                name: "Gym");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "char(6)", nullable: false),
                    Street = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.IdAddress);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    IdGym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAddress = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.IdGym);
                    table.ForeignKey(
                        name: "FK_Gyms_Addresses_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdRole = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Bio = table.Column<string>(type: "varchar(500)", nullable: false),
                    DietPriceFrom = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    DietPriceTo = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EmailValidated = table.Column<bool>(type: "boolean", nullable: false),
                    Height = table.Column<decimal>(type: "numeric(3,2)", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PersonalTrainingPriceFrom = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    PersonalTrainingPriceTo = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "char(11)", nullable: false),
                    Sex = table.Column<string>(type: "varchar(10)", nullable: false),
                    TrainingPlanPriceFrom = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    TrainingPlanPriceTo = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "numeric(3,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id_Diet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Dietician = table.Column<int>(type: "integer", nullable: false),
                    Id_Pupil = table.Column<int>(type: "integer", nullable: false),
                    DietDuration = table.Column<string>(type: "text", nullable: false),
                    End_Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Total_kcal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id_Diet);
                    table.ForeignKey(
                        name: "FK_Diets_Users_Id_Dietician",
                        column: x => x.Id_Dietician,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Users_Id_Pupil",
                        column: x => x.Id_Pupil,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    IdExercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTrainer = table.Column<int>(type: "integer", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    ExerciseSteps = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.IdExercise);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_IdTrainer",
                        column: x => x.IdTrainer,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id_Meal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Dietetician = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    Kcal = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Prepare_Steps = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id_Meal);
                    table.ForeignKey(
                        name: "FK_Meals_Users_Id_Dietetician",
                        column: x => x.Id_Dietetician,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    IdPupil = table.Column<int>(type: "integer", nullable: false),
                    IdMentor = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "varchar(1000)", nullable: false),
                    OpinionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => new { x.IdPupil, x.IdMentor });
                    table.ForeignKey(
                        name: "FK_Opinions_Users_IdMentor",
                        column: x => x.IdMentor,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinions_Users_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pupil_mentors",
                columns: table => new
                {
                    IdMentor = table.Column<int>(type: "integer", nullable: false),
                    IdPupil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupil_mentors", x => new { x.IdMentor, x.IdPupil });
                    table.ForeignKey(
                        name: "FK_Pupil_mentors_Users_IdMentor",
                        column: x => x.IdMentor,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pupil_mentors_Users_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer_Gyms",
                columns: table => new
                {
                    IdTrainerGym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdGym = table.Column<int>(type: "integer", nullable: false),
                    IdTrainer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer_Gyms", x => new { x.IdGym, x.IdTrainer });
                    table.ForeignKey(
                        name: "FK_Trainer_Gyms_Gyms_IdGym",
                        column: x => x.IdGym,
                        principalTable: "Gyms",
                        principalColumn: "IdGym",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainer_Gyms_Users_IdTrainer",
                        column: x => x.IdTrainer,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training_plans",
                columns: table => new
                {
                    IdTrainingPlan = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPupil = table.Column<int>(type: "integer", nullable: true),
                    IdTrainer = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    PlanDuration = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_plans", x => x.IdTrainingPlan);
                    table.ForeignKey(
                        name: "FK_Training_plans_Users_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                    table.ForeignKey(
                        name: "FK_Training_plans_Users_IdTrainer",
                        column: x => x.IdTrainer,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meal_Diets",
                columns: table => new
                {
                    IdMealDiet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMeal = table.Column<int>(type: "integer", nullable: false),
                    IdDiet = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "varchar(200)", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal_Diets", x => new { x.IdMeal, x.IdDiet });
                    table.ForeignKey(
                        name: "FK_Meal_Diets_Diets_IdDiet",
                        column: x => x.IdDiet,
                        principalTable: "Diets",
                        principalColumn: "Id_Diet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meal_Diets_Meals_IdMeal",
                        column: x => x.IdMeal,
                        principalTable: "Meals",
                        principalColumn: "Id_Meal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainee_exercises",
                columns: table => new
                {
                    IdTraineeExercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdExercise = table.Column<int>(type: "integer", nullable: false),
                    IdTrainingPlan = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    RepetitionsNumber = table.Column<int>(type: "integer", nullable: false),
                    SeriesNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee_exercises", x => x.IdTraineeExercise);
                    table.ForeignKey(
                        name: "FK_Trainee_exercises_Exercises_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercises",
                        principalColumn: "IdExercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainee_exercises_Training_plans_IdTrainingPlan",
                        column: x => x.IdTrainingPlan,
                        principalTable: "Training_plans",
                        principalColumn: "IdTrainingPlan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "IdAddress", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "02-222", "Zlota" },
                    { 2, "Białystok", "02-324", "Kryształowa" },
                    { 3, "Kraków", "02-421", "Mendelejewa" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Image", "Name" },
                values: new object[,]
                {
                    { 3, "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.", "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]", null, null, "Plank" },
                    { 14, "Ćwiczenie wzmacniające mięśnie nóg i pośladków", "1. Stań w rozkroku i ugnij nogi w kolanach", null, null, "Przysiady" },
                    { 15, "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.", "W podporze przodem ugnij ręcę w łokciach", null, null, "Pompki" },
                    { 16, "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.", "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.", null, null, "Boczny plank" },
                    { 17, "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.", "W pozycji planku na przedramionach, unieś na przemian każdą nogę.", null, null, "Plank z podnoszeniem nóg" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Pupil" },
                    { 3, "Trainer" },
                    { 4, "Dietician" },
                    { 5, "Dietician-Trainer" }
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "IdGym", "IdAddress", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Gym1" },
                    { 2, 2, "Gym2" },
                    { 3, 3, "Gym3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Age", "Bio", "DietPriceFrom", "DietPriceTo", "Email", "EmailValidated", "Height", "IdRole", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo", "Weight" },
                values: new object[,]
                {
                    { 1, null, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, "michal@gmail.com", true, null, 1, "Emczyk", "Michał", null, null, "48777888777", "Male", null, null, null },
                    { 2, null, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, "anna@gmail.com", true, null, 2, "Kowalska", "Anna", null, null, "48666778888", "Female", null, null, null },
                    { 3, null, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, "john@gmail.com", true, null, 3, "Doe", "John", null, null, "48555667777", "Male", null, null, null },
                    { 4, null, "Hi, I'm Charlie. Let's stay active and have fun!", null, null, "charlie@gmail.com", true, null, 3, "Brown", "Charlie", null, null, "48554567890", "Male", null, null, null },
                    { 5, null, "Hello, I'm Diana. Fitness is my passion!", null, null, "diana@gmail.com", true, null, 3, "Miller", "Diana", null, null, "48555678901", "Female", null, null, null },
                    { 6, null, "Hi, I'm Frank. Let's achieve our fitness goals together!", null, null, "frank@gmail.com", true, null, 3, "Davis", "Frank", null, null, "48556789012", "Male", null, null, null },
                    { 7, null, "Hello, I'm Grace. Fitness is my lifestyle!", null, null, "grace@gmail.com", true, null, 3, "Anderson", "Grace", null, null, "48557890123", "Female", null, null, null },
                    { 8, null, "Hey, I'm Harry. Let's push our limits in every workout!", null, null, "harry@gmail.com", true, null, 3, "Moore", "Harry", null, null, "48558901234", "Male", null, null, null },
                    { 9, null, "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!", null, null, "ivy@gmail.com", true, null, 3, "Turner", "Ivy", null, null, "48559012345", "Female", null, null, null },
                    { 10, null, "Hello, I'm Jack. Let's make every workout count!", null, null, "jack@gmail.com", true, null, 3, "White", "Jack", null, null, "48550123456", "Male", null, null, null },
                    { 11, null, "Hi, I'm Kelly. Fitness is the key to a healthy life!", null, null, "kelly@gmail.com", true, null, 3, "Martin", "Kelly", null, null, "48551234567", "Female", null, null, null },
                    { 12, null, "Hey, I'm Leo. Let's crush our fitness goals!", null, null, "leo@gmail.com", true, null, 3, "Baker", "Leo", null, null, "48552345678", "Male", null, null, null },
                    { 13, null, "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!", null, null, "mia@gmail.com", true, null, 3, "Collins", "Mia", null, null, "48553456789", "Female", null, null, null },
                    { 14, null, "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!", null, null, "nathan@gmail.com", true, null, 3, "Ward", "Nathan", null, null, "48554567890", "Male", null, null, null },
                    { 15, null, "Hey, I'm Olivia. Fitness enthusiast and advocate!", null, null, "olivia@gmail.com", true, null, 3, "Perry", "Olivia", null, null, "48555678901", "Female", null, null, null },
                    { 16, null, "Hello, I'm Peter. Let's make fitness a fun journey!", null, null, "peter@gmail.com", true, null, 3, "Cooper", "Peter", null, null, "48556789012", "Male", null, null, null },
                    { 17, null, "Hi, I'm Quinn. Fitness is my daily dose of happiness!", null, null, "quinn@gmail.com", true, null, 3, "Barnes", "Quinn", null, null, "48557890123", "Female", null, null, null },
                    { 18, null, "Hey, I'm Ryan. Fitness is the key to a balanced life!", null, null, "ryan@gmail.com", true, null, 3, "Fisher", "Ryan", null, null, "48558901234", "Male", null, null, null },
                    { 19, null, "Hello, I'm Sophie. Let's stay fit and fabulous!", null, null, "sophie@gmail.com", true, null, 3, "Turner", "Sophie", null, null, "48559012345", "Female", null, null, null },
                    { 20, null, "Hi, I'm Tom. Fitness is my lifestyle choice!", null, null, "tom@gmail.com", true, null, 3, "Harris", "Tom", null, null, "48550123456", "Male", null, null, null },
                    { 21, null, "Hi, I'm Filip. Fitness is my hobby!", null, null, "filipwgmail.com", true, null, 4, "W", "Filip", null, null, "48550123456", "Male", null, null, null },
                    { 22, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 3, "test", "test", null, null, "48550123456", "Male", null, null, null },
                    { 23, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 3, "test", "test", null, null, "48550123456", "Male", null, null, null },
                    { 24, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 3, "test", "test", null, null, "48550123456", "Male", null, null, null },
                    { 25, null, "Hi, I'm Jakub. Fitness is my passion!", null, null, "jakubs@gmail.com", true, null, 5, "test", "Dietician-Trainer", null, null, "48550123456", "Male", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id_Diet", "DietDuration", "End_Date", "Id_Dietician", "Id_Pupil", "Start_Date", "Total_kcal" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000 },
                    { 2, "30", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000 },
                    { 3, "30", new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.", "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]", 1, null, "Pompki" },
                    { 2, "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.", "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2: Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.", 1, null, "Przysiady" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id_Meal", "Id_Dietetician", "Image", "Ingredients", "Kcal", "Name", "Prepare_Steps" },
                values: new object[,]
                {
                    { 1, 1, null, "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }", "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }", "Placki ziemniaczane", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 2, 1, null, "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }", "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }", "Owsianka", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 3, 2, null, "{\"ingredient1\": \"szynka\", \"ingredient2\": \"chleb\", \"ingredient3\":  \"masło\" }", "{\"kcal\": \"700\", \"Białko\": \"30\", \"Węglowodany\":  \"200\" , \"Tłuszcze\": \"26\" }", "Kanapki z szynką", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" }
                });

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "IdMentor", "IdPupil", "Content", "OpinionDate", "Rate" },
                values: new object[,]
                {
                    { 1, 2, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 1, 3, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 22, 5, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m },
                    { 22, 6, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 23, 7, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 23, 8, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m }
                });

            migrationBuilder.InsertData(
                table: "Pupil_mentors",
                columns: new[] { "IdMentor", "IdPupil" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trainer_Gyms",
                columns: new[] { "IdGym", "IdTrainer" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Training_plans",
                columns: new[] { "IdTrainingPlan", "EndDate", "IdPupil", "IdTrainer", "Name", "PlanDuration", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Plan treningowy dla początkujących", null, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siłowy" },
                    { 2, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Plan treningowy na odchudzanie", null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "Meal_Diets",
                columns: new[] { "IdDiet", "IdMeal", "Comments", "Date", "IdMealDiet" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, null, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, 2, null, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Trainee_exercises",
                columns: new[] { "IdTraineeExercise", "Comments", "Date", "IdExercise", "IdTrainingPlan", "RepetitionsNumber", "SeriesNumber" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 12, 3 },
                    { 2, null, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 10, 4 },
                    { 3, null, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 15, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_Id_Dietician",
                table: "Diets",
                column: "Id_Dietician");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_Id_Pupil",
                table: "Diets",
                column: "Id_Pupil");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_IdTrainer",
                table: "Exercises",
                column: "IdTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_IdAddress",
                table: "Gyms",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Diets_IdDiet",
                table: "Meal_Diets",
                column: "IdDiet");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_Id_Dietetician",
                table: "Meals",
                column: "Id_Dietetician");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_IdMentor",
                table: "Opinions",
                column: "IdMentor");

            migrationBuilder.CreateIndex(
                name: "IX_Pupil_mentors_IdPupil",
                table: "Pupil_mentors",
                column: "IdPupil");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_exercises_IdExercise",
                table: "Trainee_exercises",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_exercises_IdTrainingPlan",
                table: "Trainee_exercises",
                column: "IdTrainingPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_Gyms_IdTrainer",
                table: "Trainer_Gyms",
                column: "IdTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Training_plans_IdPupil",
                table: "Training_plans",
                column: "IdPupil");

            migrationBuilder.CreateIndex(
                name: "IX_Training_plans_IdTrainer",
                table: "Training_plans",
                column: "IdTrainer");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
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
                    table.PrimaryKey("PK_Addresses", x => x.IdAddress);
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
                name: "Gyms",
                columns: table => new
                {
                    IdGym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdAddress = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    AddedBy = table.Column<int>(type: "integer", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ImageUri = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: true),
                    EmailConfirmationToken = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Height = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: true),
                    Sex = table.Column<string>(type: "varchar(10)", nullable: true),
                    Bio = table.Column<string>(type: "varchar(500)", nullable: true),
                    TrainingPlanPriceFrom = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TrainingPlanPriceTo = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    PersonalTrainingPriceFrom = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    PersonalTrainingPriceTo = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DietPriceFrom = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DietPriceTo = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    IdRole = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    IdCertificate = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PdfUri = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    IdMentor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.IdCertificate);
                    table.ForeignKey(
                        name: "FK_Certificates_Users_IdMentor",
                        column: x => x.IdMentor,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    IdDiet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdDietician = table.Column<int>(type: "integer", nullable: false),
                    IdPupil = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CustomName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    NumberOfWeeks = table.Column<int>(type: "integer", nullable: false),
                    TotalKcal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.IdDiet);
                    table.ForeignKey(
                        name: "FK_Diets_Users_IdDietician",
                        column: x => x.IdDietician,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Users_IdPupil",
                        column: x => x.IdPupil,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    IdExercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    ExerciseSteps = table.Column<string>(type: "text", nullable: false),
                    IdTrainer = table.Column<int>(type: "integer", nullable: true)
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
                    table.PrimaryKey("PK_Meals", x => x.IdMeal);
                    table.ForeignKey(
                        name: "FK_Meals_Users_IdDietician",
                        column: x => x.IdDietician,
                        principalTable: "Users",
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
                        name: "FK_Opinion_Users_IdMentor",
                        column: x => x.IdMentor,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinion_Users_IdPupil",
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
                    IdPupil = table.Column<int>(type: "integer", nullable: false),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CustomName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    NumberOfWeeks = table.Column<int>(type: "integer", nullable: false),
                    IdTrainer = table.Column<int>(type: "integer", nullable: false),
                    IdPupil = table.Column<int>(type: "integer", nullable: true)
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
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    HourOfMeal = table.Column<string>(type: "varchar(5)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal_Diets", x => new { x.IdMeal, x.IdDiet });
                    table.ForeignKey(
                        name: "FK_Meal_Diets_Diets_IdDiet",
                        column: x => x.IdDiet,
                        principalTable: "Diets",
                        principalColumn: "IdDiet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meal_Diets_Meals_IdMeal",
                        column: x => x.IdMeal,
                        principalTable: "Meals",
                        principalColumn: "IdMeal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainee_exercises",
                columns: table => new
                {
                    IdTraineeExercise = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeriesNumber = table.Column<int>(type: "integer", nullable: false),
                    RepetitionsNumber = table.Column<string>(type: "text", nullable: false),
                    Comments = table.Column<string>(type: "varchar(50)", nullable: true),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    IdExercise = table.Column<int>(type: "integer", nullable: false),
                    IdTrainingPlan = table.Column<int>(type: "integer", nullable: false)
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
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Name" },
                values: new object[,]
                {
                    { 3, "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.", "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]", null, "Plank" },
                    { 14, "Ćwiczenie wzmacniające mięśnie nóg i pośladków", "1. Stań w rozkroku i ugnij nogi w kolanach", null, "Przysiady" },
                    { 15, "Ćwiczenie wzmacniające mięśnie piersiowe, pleców i rąk.", "W podporze przodem ugnij ręcę w łokciach", null, "Pompki" },
                    { 16, "Ćwiczenie wzmacniające mięśnie boczne tułowia oraz ramiona.", "Połóż się na boku i podnieś biodra, tworząc prostą linię od stóp do głowy.", null, "Boczny plank" },
                    { 17, "Ćwiczenie angażujące głębokie mięśnie brzucha oraz stabilizujące biodra.", "W pozycji planku na przedramionach, unieś na przemian każdą nogę.", null, "Plank z podnoszeniem nóg" }
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
                table: "Gyms",
                columns: new[] { "IdGym", "AddedBy", "IdAddress", "IsAccepted", "Name" },
                values: new object[,]
                {
                    { 1, 0, 1, false, "Gym1" },
                    { 2, 0, 2, false, "Gym2" },
                    { 3, 0, 3, false, "Gym3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Bio", "DateOfBirth", "DietPriceFrom", "DietPriceTo", "Email", "EmailConfirmationToken", "HashedPassword", "Height", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "RefreshToken", "RefreshTokenExpirationDate", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo", "Weight" },
                values: new object[,]
                {
                    { 1, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, null, "michal@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 1, null, false, "Emczyk", "Michał", null, null, "48777888777", null, null, "Male", null, null, null },
                    { 2, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, null, "anna@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 2, null, false, "Kowalska", "Anna", null, null, "48666778888", null, null, "Female", null, null, null },
                    { 3, "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", null, null, null, "john@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Doe", "John", null, null, "48555667777", null, null, "Male", null, null, null },
                    { 4, "Hi, I'm Charlie. Let's stay active and have fun!", null, null, null, "charlie@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Brown", "Charlie", null, null, "48554567890", null, null, "Male", null, null, null },
                    { 5, "Hello, I'm Diana. Fitness is my passion!", null, null, null, "diana@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Miller", "Diana", null, null, "48555678901", null, null, "Female", null, null, null },
                    { 6, "Hi, I'm Frank. Let's achieve our fitness goals together!", null, null, null, "frank@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Davis", "Frank", null, null, "48556789012", null, null, "Male", null, null, null },
                    { 7, "Hello, I'm Grace. Fitness is my lifestyle!", null, null, null, "grace@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Anderson", "Grace", null, null, "48557890123", null, null, "Female", null, null, null },
                    { 8, "Hey, I'm Harry. Let's push our limits in every workout!", null, null, null, "harry@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Moore", "Harry", null, null, "48558901234", null, null, "Male", null, null, null },
                    { 9, "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!", null, null, null, "ivy@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Turner", "Ivy", null, null, "48559012345", null, null, "Female", null, null, null },
                    { 10, "Hello, I'm Jack. Let's make every workout count!", null, null, null, "jack@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "White", "Jack", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 11, "Hi, I'm Kelly. Fitness is the key to a healthy life!", null, null, null, "kelly@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Martin", "Kelly", null, null, "48551234567", null, null, "Female", null, null, null },
                    { 12, "Hey, I'm Leo. Let's crush our fitness goals!", null, null, null, "leo@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Baker", "Leo", null, null, "48552345678", null, null, "Male", null, null, null },
                    { 13, "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!", null, null, null, "mia@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Collins", "Mia", null, null, "48553456789", null, null, "Female", null, null, null },
                    { 14, "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!", null, null, null, "nathan@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Ward", "Nathan", null, null, "48554567890", null, null, "Male", null, null, null },
                    { 15, "Hey, I'm Olivia. Fitness enthusiast and advocate!", null, null, null, "olivia@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Perry", "Olivia", null, null, "48555678901", null, null, "Female", null, null, null },
                    { 16, "Hello, I'm Peter. Let's make fitness a fun journey!", null, null, null, "peter@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Cooper", "Peter", null, null, "48556789012", null, null, "Male", null, null, null },
                    { 17, "Hi, I'm Quinn. Fitness is my daily dose of happiness!", null, null, null, "quinn@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Barnes", "Quinn", null, null, "48557890123", null, null, "Female", null, null, null },
                    { 18, "Hey, I'm Ryan. Fitness is the key to a balanced life!", null, null, null, "ryan@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Fisher", "Ryan", null, null, "48558901234", null, null, "Male", null, null, null },
                    { 19, "Hello, I'm Sophie. Let's stay fit and fabulous!", null, null, null, "sophie@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Turner", "Sophie", null, null, "48559012345", null, null, "Female", null, null, null },
                    { 20, "Hi, I'm Tom. Fitness is my lifestyle choice!", null, null, null, "tom@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Harris", "Tom", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 21, "Hi, I'm Filip. Fitness is my hobby!", null, null, null, "filipwgmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 4, null, false, "W", "Filip", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 22, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "test", "test", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 23, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "test", "test", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 24, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "test", "test", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 25, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", null, "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 5, null, false, "test", "Dietician-Trainer", null, null, "48550123456", null, null, "Male", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "IdDiet", "CustomName", "IdDietician", "IdPupil", "Name", "NumberOfWeeks", "StartDate", "TotalKcal", "Type" },
                values: new object[,]
                {
                    { 1, "Plan treningowy dla mirka", 1, 2, "Plan treningowy dla początkujących", 4, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000, "Siłowy" },
                    { 2, "Plan treningowy dla jacka", 1, 2, "Plan treningowy na odchudzanie", 4, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, "Cardio" },
                    { 3, "Plan treningowy dla Wlodara", 1, 2, "Plan treningowy dla początkujących", 4, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, "Siłowy" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "IdExercise", "Details", "ExerciseSteps", "IdTrainer", "Name" },
                values: new object[,]
                {
                    { 1, "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.", "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]", 1, "Pompki" },
                    { 2, "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.", "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2: Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.", 1, "Przysiady" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
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
                table: "Pupil_mentors",
                columns: new[] { "IdMentor", "IdPupil", "IsAccepted" },
                values: new object[,]
                {
                    { 1, 2, false },
                    { 1, 3, false }
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
                columns: new[] { "IdTrainingPlan", "CustomName", "IdPupil", "IdTrainer", "Name", "NumberOfWeeks", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, "Plan treningowy dla mirka", 2, 1, "Plan treningowy dla początkujących", 0, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siłowy" },
                    { 2, "Plan treningowy dla jacka", 2, 1, "Plan treningowy na odchudzanie", 0, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cardio" }
                });

            migrationBuilder.InsertData(
                table: "Meal_Diets",
                columns: new[] { "IdDiet", "IdMeal", "Comments", "DayOfWeek", "HourOfMeal", "IdMealDiet" },
                values: new object[,]
                {
                    { 1, 1, "Jedz sobie", 1, "12:00", 1 },
                    { 2, 1, null, 1, "12:00", 3 },
                    { 1, 2, null, 2, "12:00", 2 }
                });

            migrationBuilder.InsertData(
                table: "Trainee_exercises",
                columns: new[] { "IdTraineeExercise", "Comments", "DayOfWeek", "IdExercise", "IdTrainingPlan", "RepetitionsNumber", "SeriesNumber" },
                values: new object[,]
                {
                    { 1, null, 5, 1, 1, "12", 3 },
                    { 2, null, 1, 2, 1, "10", 4 },
                    { 3, null, 2, 3, 2, "15", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IdMentor",
                table: "Certificates",
                column: "IdMentor");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_IdDietician",
                table: "Diets",
                column: "IdDietician");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_IdPupil",
                table: "Diets",
                column: "IdPupil");

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
                name: "IX_Meals_IdDietician",
                table: "Meals",
                column: "IdDietician");

            migrationBuilder.CreateIndex(
                name: "IX_Opinion_IdMentor",
                table: "Opinion",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Meal_Diets");

            migrationBuilder.DropTable(
                name: "Opinion");

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
                name: "Role");
        }
    }
}

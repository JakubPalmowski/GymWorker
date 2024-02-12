using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDatachanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumn: "IdMealDiet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumn: "IdMealDiet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meal_Diets",
                keyColumn: "IdMealDiet",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "IdMeal",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 23, 7 });

            migrationBuilder.DeleteData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 23, 8 });

            migrationBuilder.DeleteData(
                table: "Pupil_mentors",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Pupil_mentors",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training_plans",
                keyColumn: "IdTrainingPlan",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diets",
                keyColumn: "IdDiet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "IdMeal",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "IdMeal",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "IdAddress",
                keyValue: 1,
                column: "Street",
                value: "Wołoska");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "IdAddress",
                keyValue: 2,
                columns: new[] { "City", "Street" },
                values: new object[] { "Warszawa", "Złota" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "IdAddress",
                keyValue: 3,
                columns: new[] { "City", "Street" },
                values: new object[] { "Warszawa", "Syta" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 1,
                column: "Name",
                value: "McFit Wołoska");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                column: "Name",
                value: "CityFit Centrum");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                column: "Name",
                value: "CityFit Wilanów");

            migrationBuilder.InsertData(
                table: "Trainer_Gyms",
                columns: new[] { "IdGym", "IdTrainer" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "Bio", "HashedPassword", "IdRole" },
                values: new object[] { "Pasjonat zdrowego stylu życia i fitnessu. Z ponad 5-letnim doświadczeniem jako trener personalny, pomogłem wielu osobom osiągnąć ich cele zdrowotne i kondycyjne. Specjalizuję się w treningach siłowych, kondycyjnych oraz w doradztwie żywieniowym.", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "Bio", "HashedPassword", "IdRole" },
                values: new object[] { "Zawodowa trenerka fitness z pasją do jogi i pilatesu. Uwielbiam inspirować innych do prowadzenia zdrowszego trybu życia. Moje sesje treningowe są energiczne, motywujące i dostosowane do indywidualnych potrzeb każdego klienta.", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "LastName", "Name" },
                values: new object[] { "Dietetyk kliniczny z zamiłowaniem do sportu. Moje podejście łączy naukowe podstawy żywienia z praktycznymi poradami, które pomagają klientom osiągnąć ich cele zdrowotne bez poświęcania przyjemności jedzenia.", "andrzej@gmail.com", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", 4, "Kowalski", "Andrzej" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "LastName", "Name" },
                values: new object[] { "Ekspert od wellness i poprawy samopoczucia, z certyfikatem dietetyka. Zajmuję się holistycznym podejściem do zdrowia, łączac odżywianie i mentalność, aby wspierać klientów w osiąganiu zrównoważonego stylu życia.", "marcin@gmail.com", "$2a$11$WLvEJW0cgBdb0f81E9tt/uB41IskjQuuNsVFT7eJFpYl.aqSdhlSu", 4, "Michalski", "Marcin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "IdAddress",
                keyValue: 1,
                column: "Street",
                value: "Zlota");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "IdAddress",
                keyValue: 2,
                columns: new[] { "City", "Street" },
                values: new object[] { "Białystok", "Kryształowa" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "IdAddress",
                keyValue: 3,
                columns: new[] { "City", "Street" },
                values: new object[] { "Kraków", "Mendelejewa" });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "IdDiet", "CustomName", "IdDietician", "IdPupil", "Name", "NumberOfWeeks", "StartDate", "TotalKcal", "Type" },
                values: new object[,]
                {
                    { 1, "Plan treningowy dla mirka", 1, 2, "Plan treningowy dla początkujących", 4, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000, "Siłowy" },
                    { 2, "Plan treningowy dla jacka", 1, 2, "Plan treningowy na odchudzanie", 4, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, "Cardio" },
                    { 3, "Plan treningowy dla Wlodara", 1, 2, "Plan treningowy dla początkujących", 4, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, "Siłowy" }
                });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 1,
                column: "Name",
                value: "Gym1");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 2,
                column: "Name",
                value: "Gym2");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "IdGym",
                keyValue: 3,
                column: "Name",
                value: "Gym3");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "IdMeal", "IdDietician", "Ingredients", "Kcal", "Name", "PrepareSteps" },
                values: new object[,]
                {
                    { 1, 1, "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }", "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }", "Placki ziemniaczane", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 2, 1, "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }", "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }", "Owsianka", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 3, 2, "{\"ingredient1\": \"szynka\", \"ingredient2\": \"chleb\", \"ingredient3\":  \"masło\" }", "{\"kcal\": \"700\", \"Białko\": \"30\", \"Węglowodany\":  \"200\" , \"Tłuszcze\": \"26\" }", "Kanapki z szynką", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" }
                });

            migrationBuilder.InsertData(
                table: "Opinion",
                columns: new[] { "IdMentor", "IdPupil", "Content", "OpinionDate", "Rate" },
                values: new object[,]
                {
                    { 1, 2, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 1, 3, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m }
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                columns: new[] { "Bio", "HashedPassword", "IdRole" },
                values: new object[] { "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", "adsas321312dasasdasdajgfasdjiasijdasujnasd", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                columns: new[] { "Bio", "HashedPassword", "IdRole" },
                values: new object[] { "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", "adsas321312dasasdasdajgfasdjiasijdasujnasd", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "LastName", "Name" },
                values: new object[] { "Cześć jestem Kuba i dużo trenuje. Zapraszam na treningi indywidualne", "john@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", 3, "Doe", "John" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                columns: new[] { "Bio", "Email", "HashedPassword", "IdRole", "LastName", "Name" },
                values: new object[] { "Hi, I'm Charlie. Let's stay active and have fun!", "charlie@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", 3, "Brown", "Charlie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Bio", "DateOfBirth", "DietPriceFrom", "DietPriceTo", "Email", "HashedPassword", "Height", "IdRole", "ImageUri", "IsAccepted", "LastName", "Name", "PersonalTrainingPriceFrom", "PersonalTrainingPriceTo", "PhoneNumber", "RefreshToken", "RefreshTokenExpirationDate", "Sex", "TrainingPlanPriceFrom", "TrainingPlanPriceTo", "Weight" },
                values: new object[,]
                {
                    { 5, "Hello, I'm Diana. Fitness is my passion!", null, null, null, "diana@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Miller", "Diana", null, null, "48555678901", null, null, "Female", null, null, null },
                    { 6, "Hi, I'm Frank. Let's achieve our fitness goals together!", null, null, null, "frank@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Davis", "Frank", null, null, "48556789012", null, null, "Male", null, null, null },
                    { 7, "Hello, I'm Grace. Fitness is my lifestyle!", null, null, null, "grace@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Anderson", "Grace", null, null, "48557890123", null, null, "Female", null, null, null },
                    { 8, "Hey, I'm Harry. Let's push our limits in every workout!", null, null, null, "harry@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Moore", "Harry", null, null, "48558901234", null, null, "Male", null, null, null },
                    { 9, "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!", null, null, null, "ivy@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Turner", "Ivy", null, null, "48559012345", null, null, "Female", null, null, null },
                    { 10, "Hello, I'm Jack. Let's make every workout count!", null, null, null, "jack@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "White", "Jack", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 11, "Hi, I'm Kelly. Fitness is the key to a healthy life!", null, null, null, "kelly@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Martin", "Kelly", null, null, "48551234567", null, null, "Female", null, null, null },
                    { 12, "Hey, I'm Leo. Let's crush our fitness goals!", null, null, null, "leo@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Baker", "Leo", null, null, "48552345678", null, null, "Male", null, null, null },
                    { 13, "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!", null, null, null, "mia@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Collins", "Mia", null, null, "48553456789", null, null, "Female", null, null, null },
                    { 14, "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!", null, null, null, "nathan@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Ward", "Nathan", null, null, "48554567890", null, null, "Male", null, null, null },
                    { 15, "Hey, I'm Olivia. Fitness enthusiast and advocate!", null, null, null, "olivia@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Perry", "Olivia", null, null, "48555678901", null, null, "Female", null, null, null },
                    { 16, "Hello, I'm Peter. Let's make fitness a fun journey!", null, null, null, "peter@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Cooper", "Peter", null, null, "48556789012", null, null, "Male", null, null, null },
                    { 17, "Hi, I'm Quinn. Fitness is my daily dose of happiness!", null, null, null, "quinn@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Barnes", "Quinn", null, null, "48557890123", null, null, "Female", null, null, null },
                    { 18, "Hey, I'm Ryan. Fitness is the key to a balanced life!", null, null, null, "ryan@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Fisher", "Ryan", null, null, "48558901234", null, null, "Male", null, null, null },
                    { 19, "Hello, I'm Sophie. Let's stay fit and fabulous!", null, null, null, "sophie@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Turner", "Sophie", null, null, "48559012345", null, null, "Female", null, null, null },
                    { 20, "Hi, I'm Tom. Fitness is my lifestyle choice!", null, null, null, "tom@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "Harris", "Tom", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 21, "Hi, I'm Filip. Fitness is my hobby!", null, null, null, "filipwgmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 4, null, false, "W", "Filip", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 22, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "test", "test", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 23, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "test", "test", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 24, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 3, null, false, "test", "test", null, null, "48550123456", null, null, "Male", null, null, null },
                    { 25, "Hi, I'm Jakub. Fitness is my passion!", null, null, null, "jakubs@gmail.com", "adsas321312dasasdasdajgfasdjiasijdasujnasd", null, 5, null, false, "test", "Dietician-Trainer", null, null, "48550123456", null, null, "Male", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Meal_Diets",
                columns: new[] { "IdMealDiet", "Comments", "DayOfWeek", "HourOfMeal", "IdDiet", "IdMeal" },
                values: new object[,]
                {
                    { 1, "Jedz sobie", 1, "12:00", 1, 1 },
                    { 2, null, 2, "12:00", 1, 2 },
                    { 3, null, 1, "12:00", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Opinion",
                columns: new[] { "IdMentor", "IdPupil", "Content", "OpinionDate", "Rate" },
                values: new object[,]
                {
                    { 22, 5, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m },
                    { 22, 6, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 23, 7, "zne, a jednocześnie przyjazne i motywująmocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 23, 8, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m }
                });
        }
    }
}

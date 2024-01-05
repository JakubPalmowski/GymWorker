using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedDataWithNewTrainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Age", "Bio", "Email", "Email_validated", "Height", "Id_Address", "Id_Role", "Last_name", "Name", "Phone_number", "Sex", "Weight" },
                values: new object[,]
                {
                    { 4, null, "Hi, I'm Charlie. Let's stay active and have fun!", "charlie@gmail.com", true, null, 1, 3, "Brown", "Charlie", "48554567890", "Male", null },
                    { 5, null, "Hello, I'm Diana. Fitness is my passion!", "diana@gmail.com", true, null, 2, 3, "Miller", "Diana", "48555678901", "Female", null },
                    { 6, null, "Hi, I'm Frank. Let's achieve our fitness goals together!", "frank@gmail.com", true, null, 3, 3, "Davis", "Frank", "48556789012", "Male", null },
                    { 7, null, "Hello, I'm Grace. Fitness is my lifestyle!", "grace@gmail.com", true, null, 1, 3, "Anderson", "Grace", "48557890123", "Female", null },
                    { 8, null, "Hey, I'm Harry. Let's push our limits in every workout!", "harry@gmail.com", true, null, 2, 3, "Moore", "Harry", "48558901234", "Male", null },
                    { 9, null, "Hi, I'm Ivy. Fitness is my passion and I'm here to inspire!", "ivy@gmail.com", true, null, 3, 3, "Turner", "Ivy", "48559012345", "Female", null },
                    { 10, null, "Hello, I'm Jack. Let's make every workout count!", "jack@gmail.com", true, null, 1, 3, "White", "Jack", "48550123456", "Male", null },
                    { 11, null, "Hi, I'm Kelly. Fitness is the key to a healthy life!", "kelly@gmail.com", true, null, 2, 3, "Martin", "Kelly", "48551234567", "Female", null },
                    { 12, null, "Hey, I'm Leo. Let's crush our fitness goals!", "leo@gmail.com", true, null, 3, 3, "Baker", "Leo", "48552345678", "Male", null },
                    { 13, null, "Hello, I'm Mia. Fitness is not just a hobby, it's a way of life!", "mia@gmail.com", true, null, 1, 3, "Collins", "Mia", "48553456789", "Female", null },
                    { 14, null, "Hi, I'm Nathan. Let's embrace a fit and healthy lifestyle!", "nathan@gmail.com", true, null, 2, 3, "Ward", "Nathan", "48554567890", "Male", null },
                    { 15, null, "Hey, I'm Olivia. Fitness enthusiast and advocate!", "olivia@gmail.com", true, null, 3, 3, "Perry", "Olivia", "48555678901", "Female", null },
                    { 16, null, "Hello, I'm Peter. Let's make fitness a fun journey!", "peter@gmail.com", true, null, 1, 3, "Cooper", "Peter", "48556789012", "Male", null },
                    { 17, null, "Hi, I'm Quinn. Fitness is my daily dose of happiness!", "quinn@gmail.com", true, null, 2, 3, "Barnes", "Quinn", "48557890123", "Female", null },
                    { 18, null, "Hey, I'm Ryan. Fitness is the key to a balanced life!", "ryan@gmail.com", true, null, 3, 3, "Fisher", "Ryan", "48558901234", "Male", null },
                    { 19, null, "Hello, I'm Sophie. Let's stay fit and fabulous!", "sophie@gmail.com", true, null, 1, 3, "Turner", "Sophie", "48559012345", "Female", null },
                    { 20, null, "Hi, I'm Tom. Fitness is my lifestyle choice!", "tom@gmail.com", true, null, 2, 3, "Harris", "Tom", "48550123456", "Male", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 20);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class newRolesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Dietician" },
                    { 6, "Dietician-Trainer" }
                });

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1,
                column: "Plan_Duration",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Age", "Bio", "Email", "Email_validated", "Height", "Id_Address", "Id_Role", "Last_name", "Name", "Phone_number", "Sex", "Weight" },
                values: new object[,]
                {
                    { 21, null, "Hi, I'm Filip. Fitness is my hobby!", "filipwgmail.com", true, null, 2, 5, "W", "Filip", "48550123456", "Male", null },
                    { 22, null, "Hi, I'm Jakub. Fitness is my passion!", "jakubs@gmail.com", true, null, 2, 5, "S", "Jakub", "48550123456", "Male", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Training_plans",
                keyColumn: "Id_Training_plan",
                keyValue: 1,
                column: "Plan_Duration",
                value: 21);
        }
    }
}

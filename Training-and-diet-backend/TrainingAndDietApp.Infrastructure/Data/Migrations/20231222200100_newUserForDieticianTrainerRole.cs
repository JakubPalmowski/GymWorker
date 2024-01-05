using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class newUserForDieticianTrainerRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Age", "Bio", "Email", "Email_validated", "Height", "Id_Address", "Id_Role", "Last_name", "Name", "Phone_number", "Sex", "Weight" },
                values: new object[] { 25, null, "Hi, I'm Jakub. Fitness is my passion!", "jakubs@gmail.com", true, null, 2, 5, "test", "Dietician-Trainer", "48550123456", "Male", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 25);
        }
    }
}

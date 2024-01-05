using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class newSeedDataForOpinions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id_Mentor", "Id_Pupil", "Content", "Opinion_date", "Rate" },
                values: new object[,]
                {
                    { 22, 5, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m },
                    { 22, 6, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 22,
                columns: new[] { "Id_Role", "Last_name", "Name" },
                values: new object[] { 3, "test", "test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Age", "Bio", "Email", "Email_validated", "Height", "Id_Address", "Id_Role", "Last_name", "Name", "Phone_number", "Sex", "Weight" },
                values: new object[,]
                {
                    { 23, null, "Hi, I'm Jakub. Fitness is my passion!", "jakubs@gmail.com", true, null, 2, 3, "test", "test", "48550123456", "Male", null },
                    { 24, null, "Hi, I'm Jakub. Fitness is my passion!", "jakubs@gmail.com", true, null, 2, 3, "test", "test", "48550123456", "Male", null }
                });

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id_Mentor", "Id_Pupil", "Content", "Opinion_date", "Rate" },
                values: new object[,]
                {
                    { 23, 7, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m },
                    { 23, 8, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "Id_Mentor", "Id_Pupil" },
                keyValues: new object[] { 22, 5 });

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "Id_Mentor", "Id_Pupil" },
                keyValues: new object[] { 22, 6 });

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "Id_Mentor", "Id_Pupil" },
                keyValues: new object[] { 23, 7 });

            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumns: new[] { "Id_Mentor", "Id_Pupil" },
                keyValues: new object[] { 23, 8 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 22,
                columns: new[] { "Id_Role", "Last_name", "Name" },
                values: new object[] { 4, "S", "Jakub" });
        }
    }
}

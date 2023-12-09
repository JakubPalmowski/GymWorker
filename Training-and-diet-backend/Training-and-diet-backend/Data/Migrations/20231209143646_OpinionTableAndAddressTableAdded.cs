using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class OpinionTableAndAddressTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Address",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id_Address = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Street = table.Column<string>(type: "varchar(50)", nullable: false),
                    Postal_code = table.Column<string>(type: "char(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id_Address);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id_Pupil = table.Column<int>(type: "integer", nullable: false),
                    Id_Mentor = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Opinion_date = table.Column<DateTime>(type: "Date", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => new { x.Id_Pupil, x.Id_Mentor });
                    table.ForeignKey(
                        name: "FK_Opinions_Users_Id_Mentor",
                        column: x => x.Id_Mentor,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinions_Users_Id_Pupil",
                        column: x => x.Id_Pupil,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id_Address", "City", "Postal_code", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "02-222", "Zlota" },
                    { 2, "Białystok", "02-324", "Kryształowa" },
                    { 3, "Kraków", "02-421", "Mendelejewa" }
                });

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id_Mentor", "Id_Pupil", "Content", "Opinion_date", "Rate" },
                values: new object[,]
                {
                    { 1, 2, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m },
                    { 1, 3, "Jakub jest nie tylko świetnym trenerem, ale także osobą, która zawsze wierzyła we mnie i wspierała mnie w moich celach. Jego podejście do treningów było zawsze profesjonalne i skuteczne, a jednocześnie przyjazne i motywujące. Potrafił znaleźć w każdym z naszych zawodników mocne strony i pomóc nam w ich rozwijaniu.\nDzięki trenerowi Jakubowi, zdobyłem wiele umiejętności, które pomogły mi w osiągnięciu sukcesów na boisku. Jego wiedza i doświadczenie były bezcenne, a jego pozytywna energia i entuzjazm zawsze motywowały mnie do dalszej pracy i rozwoju.", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1,
                column: "Id_Address",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 2,
                column: "Id_Address",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 3,
                column: "Id_Address",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Address",
                table: "Users",
                column: "Id_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_Id_Mentor",
                table: "Opinions",
                column: "Id_Mentor");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_Id_Address",
                table: "Users",
                column: "Id_Address",
                principalTable: "Addresses",
                principalColumn: "Id_Address",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_Id_Address",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id_Address",
                table: "Users");
        }
    }
}

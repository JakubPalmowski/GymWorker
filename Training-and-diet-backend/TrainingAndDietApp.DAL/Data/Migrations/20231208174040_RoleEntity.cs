using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Id_Role");

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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Pupil" },
                    { 3, "Trainer" },
                    { 4, "User" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1,
                column: "Id_Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 3,
                column: "Id_Role",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Role",
                table: "Users",
                column: "Id_Role");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Id_Role",
                table: "Users",
                column: "Id_Role",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_Id_Role",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Users_Id_Role",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Id_Role",
                table: "Users",
                newName: "Role");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1,
                column: "Role",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 3,
                column: "Role",
                value: 2);
        }
    }
}

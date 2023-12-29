using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTrainer_GymAndGymEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_Id_Role",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id_Gym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Address = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id_Gym);
                    table.ForeignKey(
                        name: "FK_Gyms_Addresses_Id_Address",
                        column: x => x.Id_Address,
                        principalTable: "Addresses",
                        principalColumn: "Id_Address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer_Gyms",
                columns: table => new
                {
                    Id_Trainer_Gym = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Gym = table.Column<int>(type: "integer", nullable: false),
                    Id_Trainer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer_Gyms", x => new { x.Id_Gym, x.Id_Trainer });
                    table.ForeignKey(
                        name: "FK_Trainer_Gyms_Gyms_Id_Gym",
                        column: x => x.Id_Gym,
                        principalTable: "Gyms",
                        principalColumn: "Id_Gym",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainer_Gyms_Users_Id_Trainer",
                        column: x => x.Id_Trainer,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "Id_Gym", "Id_Address", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Gym1" },
                    { 2, 2, "Gym2" },
                    { 3, 3, "Gym3" }
                });

            migrationBuilder.InsertData(
                table: "Trainer_Gyms",
                columns: new[] { "Id_Gym", "Id_Trainer" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gyms_Id_Address",
                table: "Gyms",
                column: "Id_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_Gyms_Id_Trainer",
                table: "Trainer_Gyms",
                column: "Id_Trainer");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Id_Role",
                table: "Users",
                column: "Id_Role",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Id_Role",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Trainer_Gyms");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Id_Role",
                table: "Users",
                column: "Id_Role",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

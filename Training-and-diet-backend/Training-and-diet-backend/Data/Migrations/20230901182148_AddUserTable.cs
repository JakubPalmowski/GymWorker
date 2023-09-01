using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Training_plan_Id_Training_plan",
                table: "Trainee_exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training_plan",
                table: "Training_plan");

            migrationBuilder.RenameTable(
                name: "Training_plan",
                newName: "Training_plans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training_plans",
                table: "Training_plans",
                column: "Id_Training_plan");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Last_name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone_number = table.Column<string>(type: "char(11)", nullable: false),
                    Email_validated = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(3,2)", nullable: true),
                    Height = table.Column<decimal>(type: "numeric(3,2)", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Sex = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_User);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Training_plans_Id_Training_plan",
                table: "Trainee_exercises",
                column: "Id_Training_plan",
                principalTable: "Training_plans",
                principalColumn: "Id_Training_plan",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_exercises_Training_plans_Id_Training_plan",
                table: "Trainee_exercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training_plans",
                table: "Training_plans");

            migrationBuilder.RenameTable(
                name: "Training_plans",
                newName: "Training_plan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training_plan",
                table: "Training_plan",
                column: "Id_Training_plan");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_exercises_Training_plan_Id_Training_plan",
                table: "Trainee_exercises",
                column: "Id_Training_plan",
                principalTable: "Training_plan",
                principalColumn: "Id_Training_plan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class id_trainerIsNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_Id_Trainer",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Trainer",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_Id_Trainer",
                table: "Exercises",
                column: "Id_Trainer",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_Id_Trainer",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Trainer",
                table: "Exercises",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_Id_Trainer",
                table: "Exercises",
                column: "Id_Trainer",
                principalTable: "Users",
                principalColumn: "Id_User");
        }
    }
}

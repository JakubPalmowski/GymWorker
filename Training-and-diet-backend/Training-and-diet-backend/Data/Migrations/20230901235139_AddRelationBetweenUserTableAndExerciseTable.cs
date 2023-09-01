using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUserTableAndExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Trainer",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Id_Trainer",
                table: "Exercises",
                column: "Id_Trainer");

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

            migrationBuilder.DropIndex(
                name: "IX_Exercises_Id_Trainer",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Id_Trainer",
                table: "Exercises");
        }
    }
}

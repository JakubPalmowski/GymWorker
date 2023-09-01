using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUserAndTrainingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Pupil",
                table: "Training_plans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Trainer",
                table: "Training_plans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Training_plans_Id_Pupil",
                table: "Training_plans",
                column: "Id_Pupil");

            migrationBuilder.CreateIndex(
                name: "IX_Training_plans_Id_Trainer",
                table: "Training_plans",
                column: "Id_Trainer");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_Id_Trainer",
                table: "Training_plans",
                column: "Id_Trainer",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_Id_Trainer",
                table: "Training_plans");

            migrationBuilder.DropIndex(
                name: "IX_Training_plans_Id_Pupil",
                table: "Training_plans");

            migrationBuilder.DropIndex(
                name: "IX_Training_plans_Id_Trainer",
                table: "Training_plans");

            migrationBuilder.DropColumn(
                name: "Id_Pupil",
                table: "Training_plans");

            migrationBuilder.DropColumn(
                name: "Id_Trainer",
                table: "Training_plans");
        }
    }
}

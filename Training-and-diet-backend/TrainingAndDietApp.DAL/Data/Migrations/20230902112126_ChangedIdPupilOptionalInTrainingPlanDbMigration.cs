using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdPupilOptionalInTrainingPlanDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Pupil",
                table: "Training_plans",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Pupil",
                table: "Training_plans",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_plans_Users_Id_Pupil",
                table: "Training_plans",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentor_Users_Id_Mentor",
                table: "Pupil_mentor");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentor_Users_Id_Pupil",
                table: "Pupil_mentor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupil_mentor",
                table: "Pupil_mentor");

            migrationBuilder.RenameTable(
                name: "Pupil_mentor",
                newName: "Pupil_mentors");

            migrationBuilder.RenameIndex(
                name: "IX_Pupil_mentor_Id_Pupil",
                table: "Pupil_mentors",
                newName: "IX_Pupil_mentors_Id_Pupil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupil_mentors",
                table: "Pupil_mentors",
                columns: new[] { "Id_Mentor", "Id_Pupil" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Mentor",
                table: "Pupil_mentors",
                column: "Id_Mentor",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Pupil",
                table: "Pupil_mentors",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Mentor",
                table: "Pupil_mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_mentors_Users_Id_Pupil",
                table: "Pupil_mentors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupil_mentors",
                table: "Pupil_mentors");

            migrationBuilder.RenameTable(
                name: "Pupil_mentors",
                newName: "Pupil_mentor");

            migrationBuilder.RenameIndex(
                name: "IX_Pupil_mentors_Id_Pupil",
                table: "Pupil_mentor",
                newName: "IX_Pupil_mentor_Id_Pupil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupil_mentor",
                table: "Pupil_mentor",
                columns: new[] { "Id_Mentor", "Id_Pupil" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentor_Users_Id_Mentor",
                table: "Pupil_mentor",
                column: "Id_Mentor",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_mentor_Users_Id_Pupil",
                table: "Pupil_mentor",
                column: "Id_Pupil",
                principalTable: "Users",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

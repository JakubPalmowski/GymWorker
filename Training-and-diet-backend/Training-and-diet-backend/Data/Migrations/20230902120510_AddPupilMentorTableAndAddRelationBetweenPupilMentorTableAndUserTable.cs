using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPupilMentorTableAndAddRelationBetweenPupilMentorTableAndUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pupil_mentor",
                columns: table => new
                {
                    Id_Mentor = table.Column<int>(type: "integer", nullable: false),
                    Id_Pupil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupil_mentor", x => new { x.Id_Mentor, x.Id_Pupil });
                    table.ForeignKey(
                        name: "FK_Pupil_mentor_Users_Id_Mentor",
                        column: x => x.Id_Mentor,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pupil_mentor_Users_Id_Pupil",
                        column: x => x.Id_Pupil,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupil_mentor_Id_Pupil",
                table: "Pupil_mentor",
                column: "Id_Pupil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pupil_mentor");
        }
    }
}

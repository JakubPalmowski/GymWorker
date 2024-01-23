using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusColumnToPupilMentorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Pupil_mentors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Pupil_mentors",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 2 },
                column: "IsAccepted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Pupil_mentors",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 3 },
                column: "IsAccepted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Pupil_mentors");
        }
    }
}

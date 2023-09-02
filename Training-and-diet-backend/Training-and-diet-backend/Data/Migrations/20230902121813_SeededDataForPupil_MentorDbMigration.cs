using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataForPupil_MentorDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pupil_mentor",
                columns: new[] { "Id_Mentor", "Id_Pupil" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pupil_mentor",
                keyColumns: new[] { "Id_Mentor", "Id_Pupil" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Pupil_mentor",
                keyColumns: new[] { "Id_Mentor", "Id_Pupil" },
                keyValues: new object[] { 1, 3 });
        }
    }
}

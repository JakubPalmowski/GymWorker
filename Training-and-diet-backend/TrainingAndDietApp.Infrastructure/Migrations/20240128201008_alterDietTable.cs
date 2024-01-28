using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterDietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPupil",
                table: "Diets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPupil",
                table: "Diets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
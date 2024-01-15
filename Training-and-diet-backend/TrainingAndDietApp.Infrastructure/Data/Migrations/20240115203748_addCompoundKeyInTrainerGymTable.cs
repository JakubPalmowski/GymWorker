using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCompoundKeyInTrainerGymTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTrainerGym",
                table: "Trainer_Gyms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTrainerGym",
                table: "Trainer_Gyms",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.UpdateData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 1, 1 },
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 2, 2 },
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Trainer_Gyms",
                keyColumns: new[] { "IdGym", "IdTrainer" },
                keyValues: new object[] { 3, 3 },
                columns: new string[0],
                values: new object[0]);
        }
    }
}

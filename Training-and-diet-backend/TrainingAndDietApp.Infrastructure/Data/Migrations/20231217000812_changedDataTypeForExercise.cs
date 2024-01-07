using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedDataTypeForExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Exercise_steps",
                table: "Exercises",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "jsonb");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 2,
                column: "Exercise_steps",
                value: "Step1: Stań prosto, nogi ustawione na szerokość bioder Step 2: Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło Step: 3,Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Exercise_steps",
                table: "Exercises",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id_Exercise",
                keyValue: 2,
                column: "Exercise_steps",
                value: "[{\"Step\": 1, \"Description\": \"Stań prosto, nogi ustawione na szerokość bioder.\"}, {\"Step\": 2, \"Description\": \"Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło.\"}, {\"Step\": 3, \"Description\": \"Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.\"}]");
        }
    }
}

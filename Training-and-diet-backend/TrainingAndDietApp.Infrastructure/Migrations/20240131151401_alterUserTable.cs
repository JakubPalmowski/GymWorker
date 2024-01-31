using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmationToken",
                table: "Users");

            migrationBuilder.AlterColumn<decimal>(
                name: "TrainingPlanPriceTo",
                table: "Users",
                type: "numeric(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TrainingPlanPriceFrom",
                table: "Users",
                type: "numeric(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PersonalTrainingPriceTo",
                table: "Users",
                type: "numeric(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PersonalTrainingPriceFrom",
                table: "Users",
                type: "numeric(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DietPriceTo",
                table: "Users",
                type: "numeric(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DietPriceFrom",
                table: "Users",
                type: "numeric(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Users",
                type: "varchar(1500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TrainingPlanPriceTo",
                table: "Users",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TrainingPlanPriceFrom",
                table: "Users",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PersonalTrainingPriceTo",
                table: "Users",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PersonalTrainingPriceFrom",
                table: "Users",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DietPriceTo",
                table: "Users",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DietPriceFrom",
                table: "Users",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Users",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmationToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 23,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 24,
                column: "EmailConfirmationToken",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 25,
                column: "EmailConfirmationToken",
                value: null);
        }
    }
}

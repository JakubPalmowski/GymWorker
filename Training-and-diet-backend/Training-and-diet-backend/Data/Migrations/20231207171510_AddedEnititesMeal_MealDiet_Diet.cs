using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training_and_diet_backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEnititesMeal_MealDiet_Diet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id_Diet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Dietician = table.Column<int>(type: "integer", nullable: false),
                    Id_Pupil = table.Column<int>(type: "integer", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "Date", nullable: false),
                    End_Date = table.Column<DateTime>(type: "Date", nullable: false),
                    DietDuration = table.Column<string>(type: "text", nullable: false),
                    Total_kcal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id_Diet);
                    table.ForeignKey(
                        name: "FK_Diets_Users_Id_Dietician",
                        column: x => x.Id_Dietician,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Users_Id_Pupil",
                        column: x => x.Id_Pupil,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id_Meal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Dietetician = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "jsonb", nullable: false),
                    Prepare_Steps = table.Column<string>(type: "jsonb", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Kcal = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id_Meal);
                    table.ForeignKey(
                        name: "FK_Meals_Users_Id_Dietetician",
                        column: x => x.Id_Dietetician,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meal_Diets",
                columns: table => new
                {
                    Id_Meal_Diet = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Meal = table.Column<int>(type: "integer", nullable: false),
                    Id_Diet = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Comments = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal_Diets", x => new { x.Id_Meal, x.Id_Diet });
                    table.ForeignKey(
                        name: "FK_Meal_Diets_Diets_Id_Diet",
                        column: x => x.Id_Diet,
                        principalTable: "Diets",
                        principalColumn: "Id_Diet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meal_Diets_Meals_Id_Meal",
                        column: x => x.Id_Meal,
                        principalTable: "Meals",
                        principalColumn: "Id_Meal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id_Diet", "DietDuration", "End_Date", "Id_Dietician", "Id_Pupil", "Start_Date", "Total_kcal" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000 },
                    { 2, "30", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000 },
                    { 3, "30", new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id_Meal", "Id_Dietetician", "Image", "Ingredients", "Kcal", "Name", "Prepare_Steps" },
                values: new object[,]
                {
                    { 1, 1, null, "{\"ingredient1\": \"ziemniaki\", \"ingredient2\": \"cebula\", \"ingredient3\":  \"mąka\" }", "{\"kcal\": \"651\", \"Białko\": \"16\", \"Węglowodany\":  \"160\" , \"Tłuszcze\": \"30\" }", "Placki ziemniaczane", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 2, 1, null, "{\"ingredient1\": \"platki owsiane\", \"ingredient2\": \"mleko\", \"ingredient3\":  \"cukier\" }", "{\"kcal\": \"765\", \"Białko\": \"20\", \"Węglowodany\":  \"165\" , \"Tłuszcze\": \"20\" }", "Owsianka", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" },
                    { 3, 2, null, "{\"ingredient1\": \"szynka\", \"ingredient2\": \"chleb\", \"ingredient3\":  \"masło\" }", "{\"kcal\": \"700\", \"Białko\": \"30\", \"Węglowodany\":  \"200\" , \"Tłuszcze\": \"26\" }", "Kanapki z szynką", "{\"test1\": \"test\", \"test2\": \"test\", \"test3\":  \"test\" }" }
                });

            migrationBuilder.InsertData(
                table: "Meal_Diets",
                columns: new[] { "Id_Diet", "Id_Meal", "Comments", "Date", "Id_Meal_Diet" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, null, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, 2, null, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_Id_Dietician",
                table: "Diets",
                column: "Id_Dietician");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_Id_Pupil",
                table: "Diets",
                column: "Id_Pupil");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Diets_Id_Diet",
                table: "Meal_Diets",
                column: "Id_Diet");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_Id_Dietetician",
                table: "Meals",
                column: "Id_Dietetician");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal_Diets");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}

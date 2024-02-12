using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 3,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1099), true });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 7,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1103), true });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 11,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1107), true });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 14,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 15,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1110), true });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 16,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 17,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 18,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 19 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 10, 19 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 20 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 8, 20 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 21 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 9, 21 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 23, 38, 8, 80, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                columns: new[] { "HashedPassword", "ImageUri" },
                values: new object[] { "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                columns: new[] { "HashedPassword", "ImageUri" },
                values: new object[] { "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe", "82cbe9a9-6748-4774-a231-895c245e49c0.png" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                column: "HashedPassword",
                value: "$2a$11$SCQDlEXRjKlR5EXs3LnnCujXnZz9frsltZo80kJreOc0duq8A6CAe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                column: "HashedPassword",
                value: "$2a$11$vjBpOyisjn17k99J0UORq.RN9Fqei7WhvjJCj7qIOlxs.gDo3faq6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 3,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(875), false });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 7,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(879), false });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 11,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(883), false });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(885));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 14,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 15,
                columns: new[] { "AddedDate", "IsAccepted" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(887), false });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 16,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(888));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 17,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 18,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 19 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 10, 19 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 20 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 8, 20 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 21 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 9, 21 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                columns: new[] { "HashedPassword", "ImageUri" },
                values: new object[] { "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm", "82cbe9a9-6748-4774-a231-895c245e49c0.png" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                columns: new[] { "HashedPassword", "ImageUri" },
                values: new object[] { "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                column: "HashedPassword",
                value: "$2a$11$JGk/9yr9gUjQ4wxJcWx4HuzPGpAgUi5gQF1t9RwMmLHWFmZpzWEQO");
        }
    }
}

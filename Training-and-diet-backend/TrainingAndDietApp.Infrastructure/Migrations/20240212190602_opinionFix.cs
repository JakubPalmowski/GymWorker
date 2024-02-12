using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingAndDietApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class opinionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(875));

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
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(879));

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
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(883));

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
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(887));

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
                columns: new[] { "OpinionDate", "Rate" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1072), 4.0m });

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
                columns: new[] { "OpinionDate", "Rate" },
                values: new object[] { new DateTime(2024, 2, 12, 19, 6, 2, 238, DateTimeKind.Utc).AddTicks(1077), 5.0m });

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
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                column: "HashedPassword",
                value: "$2a$11$AXqo95Hb031LL..abXi.iuuJ4BU1pMwy1mRCSUgBZs3j5LbApFSJm");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 11,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 14,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 15,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 16,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 17,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "IdCertificate",
                keyValue: 18,
                column: "AddedDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 19 },
                columns: new[] { "OpinionDate", "Rate" },
                values: new object[] { new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1682), 4.5m });

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 10, 19 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 20 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 8, 20 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 1, 21 },
                columns: new[] { "OpinionDate", "Rate" },
                values: new object[] { new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1690), 4.8m });

            migrationBuilder.UpdateData(
                table: "Opinion",
                keyColumns: new[] { "IdMentor", "IdPupil" },
                keyValues: new object[] { 9, 21 },
                column: "OpinionDate",
                value: new DateTime(2024, 2, 12, 18, 46, 11, 384, DateTimeKind.Utc).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 3,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 4,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 5,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 6,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 7,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 8,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 9,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 10,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 11,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 12,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 13,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 14,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 15,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 16,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 17,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 18,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 19,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21,
                column: "HashedPassword",
                value: "$2a$11$G4BZAf44NMcnVIBSt3GLi.ibHM6eTx.H14jTTWq8YdWGaoqfadP7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 22,
                column: "HashedPassword",
                value: "$2a$11$7aINjux8LPZ6sHPSIHnYme/Xp11oanULdNMUyrUcgGwdAAKHCDIFW");
        }
    }
}

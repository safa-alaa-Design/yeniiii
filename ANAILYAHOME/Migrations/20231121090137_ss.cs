using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANAILYAHOME.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4d0a7ed0-0bb6-4b5a-9e19-e36f23685e2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f3b3d96a-9d2e-477d-971c-5a0747bbb139");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "27b59683-ca80-4b27-a0fa-9140821e9464");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cd6fba0c-f0c9-4a1d-998c-13966efbad02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "eb4e1419-a6bc-4165-a0b4-b6774fc4afd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a1274f78-bc60-47c6-9f1d-877bec2f8773");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANAILYAHOME.Migrations
{
    /// <inheritdoc />
    public partial class hjklş : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "57fe7e16-a512-4fb7-8192-36b60433a0b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "893831cc-ce25-41bd-9e5c-2102a093cf61");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "627e629c-d4b7-4a87-80c8-854e346fb909");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

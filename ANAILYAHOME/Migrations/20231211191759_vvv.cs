using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANAILYAHOME.Migrations
{
    /// <inheritdoc />
    public partial class vvv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pasworde",
                table: "Admenbanal",
                newName: "sirketTanim");

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Admenbanal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "katagore",
                table: "Admenbanal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "saticiadres",
                table: "Admenbanal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a8b782c3-4e4f-4613-9119-dbe07198f3a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b5ee6ddf-4f27-4814-be8c-37b6507f4f92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8b959533-7acf-4119-be36-710694e9f574");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "Admenbanal");

            migrationBuilder.DropColumn(
                name: "katagore",
                table: "Admenbanal");

            migrationBuilder.DropColumn(
                name: "saticiadres",
                table: "Admenbanal");

            migrationBuilder.RenameColumn(
                name: "sirketTanim",
                table: "Admenbanal",
                newName: "Pasworde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "16c195ac-2b0b-4819-a346-5d421b0b8bf4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "94754fae-0672-4a93-b9d4-26c343be4329");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "42366d53-d7a5-4809-ba70-8585c4534d38");
        }
    }
}

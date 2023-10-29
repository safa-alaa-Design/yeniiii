using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANAILYAHOME.Migrations
{
    /// <inheritdoc />
    public partial class otorma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "oturmaEkleModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urunKod = table.Column<int>(type: "int", nullable: false),
                    urunAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tanım = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sungurTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ahsapTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YatakOlmak = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oturmaEkleModels", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "58848c8e-9ea7-4b94-a09a-39591d58888d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1dc7d834-16da-49ff-9c41-97a079fc973b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "427fa48a-eebc-4b84-a8ff-120c40228dab");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oturmaEkleModels");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d4343dbd-5375-4d42-84ca-eb03ba8e109c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8c20ff3a-dc69-44b1-98a5-054ec2fbc433");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "bb408bd4-40b4-4c09-b006-feae3e6692ad");
        }
    }
}

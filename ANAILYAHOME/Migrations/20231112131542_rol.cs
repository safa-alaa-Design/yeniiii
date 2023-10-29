using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ANAILYAHOME.Migrations
{
    /// <inheritdoc />
    public partial class rol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ulkeler = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "emailgonder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailgonder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prodouct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    katagore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prodouct", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admenbanal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kimlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pasworde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    ŞirketAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ŞirketAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admenbanal", x => x.id);
                    table.ForeignKey(
                        name: "FK_Admenbanal_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alici",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pasword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ulkeler = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alici", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alici_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BayiKategoriler",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bayiid = table.Column<int>(type: "int", nullable: false),
                    katagore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BayiKategoriler", x => x.id);
                    table.ForeignKey(
                        name: "FK_BayiKategoriler_Admenbanal_Bayiid",
                        column: x => x.Bayiid,
                        principalTable: "Admenbanal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "urun",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urunKod = table.Column<int>(type: "int", nullable: false),
                    urunAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tanım = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ahsapTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sungurTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    katagore = table.Column<int>(type: "int", nullable: false),
                    AdmenbanalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urun", x => x.id);
                    table.ForeignKey(
                        name: "FK_urun_Admenbanal_AdmenbanalId",
                        column: x => x.AdmenbanalId,
                        principalTable: "Admenbanal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alışveriş",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    satsTarih = table.Column<int>(type: "int", nullable: false),
                    urunSaysi = table.Column<int>(type: "int", nullable: false),
                    urunTipi = table.Column<int>(type: "int", nullable: false),
                    ToplamFiyat = table.Column<int>(type: "int", nullable: false),
                    AliciId = table.Column<int>(type: "int", nullable: false),
                    urunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alışveriş", x => x.id);
                    table.ForeignKey(
                        name: "FK_alışveriş_Alici_AliciId",
                        column: x => x.AliciId,
                        principalTable: "Alici",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alışveriş_urun_urunId",
                        column: x => x.urunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buyut",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genişlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yükseklik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Derinlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyut", x => x.id);
                    table.ForeignKey(
                        name: "FK_buyut_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cocuk",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yatakTacRengi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    çekmeceliSayi = table.Column<int>(type: "int", nullable: true),
                    dulapKapiTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cocuk", x => x.id);
                    table.ForeignKey(
                        name: "FK_cocuk_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deger",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    prodouctId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deger", x => x.id);
                    table.ForeignKey(
                        name: "FK_deger_prodouct_prodouctId",
                        column: x => x.prodouctId,
                        principalTable: "prodouct",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deger_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fiyat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anafiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ulkeler = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fiyat", x => x.id);
                    table.ForeignKey(
                        name: "FK_fiyat_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "foto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foto", x => x.id);
                    table.ForeignKey(
                        name: "FK_foto_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oturma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YatakOlmak = table.Column<bool>(type: "bit", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oturma", x => x.id);
                    table.ForeignKey(
                        name: "FK_oturma_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "yatma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yatakTacRengi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    çekmeceliSayi = table.Column<int>(type: "int", nullable: true),
                    dulapKapiTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yatma", x => x.id);
                    table.ForeignKey(
                        name: "FK_yatma_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "yemek",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasaTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SandaliyeSayisi = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yemek", x => x.id);
                    table.ForeignKey(
                        name: "FK_yemek_urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cocukfiyat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kutuphane = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    calismamasasi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    yataş = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    raflar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sandaliye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fiyatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cocukfiyat", x => x.id);
                    table.ForeignKey(
                        name: "FK_cocukfiyat_fiyat_fiyatId",
                        column: x => x.fiyatId,
                        principalTable: "fiyat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oturmafiyat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ikilikultuk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    uclukultuk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pejeri = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ortaSehba = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ucluSehba = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fiyatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oturmafiyat", x => x.id);
                    table.ForeignKey(
                        name: "FK_oturmafiyat_fiyat_fiyatId",
                        column: x => x.fiyatId,
                        principalTable: "fiyat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "yatmafiyat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aynafiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    boffiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    yidilik = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sanduk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sandaliye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    konsol = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    anbarli = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    yataş = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    yatakçekmeceli = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fiyatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yatmafiyat", x => x.id);
                    table.ForeignKey(
                        name: "FK_yatmafiyat_fiyat_fiyatId",
                        column: x => x.fiyatId,
                        principalTable: "fiyat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "yemekfiyat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sandaliye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fiyatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yemekfiyat", x => x.id);
                    table.ForeignKey(
                        name: "FK_yemekfiyat_fiyat_fiyatId",
                        column: x => x.fiyatId,
                        principalTable: "fiyat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "2d7504cb-49c1-48ab-8d4f-7e7111ef1fa0", "ADMIN", "admin" },
                    { 2, "d4c36df3-84e9-4a08-9602-a55997427cf9", "SATICI", "Satici" },
                    { 3, "684d5ef2-45f4-48de-b805-67f8aef21aee", "USER", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admenbanal_userId",
                table: "Admenbanal",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alici_userId",
                table: "Alici",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_alışveriş_AliciId",
                table: "alışveriş",
                column: "AliciId");

            migrationBuilder.CreateIndex(
                name: "IX_alışveriş_urunId",
                table: "alışveriş",
                column: "urunId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BayiKategoriler_Bayiid",
                table: "BayiKategoriler",
                column: "Bayiid");

            migrationBuilder.CreateIndex(
                name: "IX_buyut_UrunId",
                table: "buyut",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_cocuk_UrunId",
                table: "cocuk",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cocukfiyat_fiyatId",
                table: "cocukfiyat",
                column: "fiyatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deger_prodouctId",
                table: "deger",
                column: "prodouctId");

            migrationBuilder.CreateIndex(
                name: "IX_deger_UrunId",
                table: "deger",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fiyat_UrunId",
                table: "fiyat",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_foto_UrunId",
                table: "foto",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_oturma_UrunId",
                table: "oturma",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_oturmafiyat_fiyatId",
                table: "oturmafiyat",
                column: "fiyatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_urun_AdmenbanalId",
                table: "urun",
                column: "AdmenbanalId");

            migrationBuilder.CreateIndex(
                name: "IX_yatma_UrunId",
                table: "yatma",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_yatmafiyat_fiyatId",
                table: "yatmafiyat",
                column: "fiyatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_yemek_UrunId",
                table: "yemek",
                column: "UrunId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_yemekfiyat_fiyatId",
                table: "yemekfiyat",
                column: "fiyatId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alışveriş");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BayiKategoriler");

            migrationBuilder.DropTable(
                name: "buyut");

            migrationBuilder.DropTable(
                name: "cocuk");

            migrationBuilder.DropTable(
                name: "cocukfiyat");

            migrationBuilder.DropTable(
                name: "deger");

            migrationBuilder.DropTable(
                name: "emailgonder");

            migrationBuilder.DropTable(
                name: "foto");

            migrationBuilder.DropTable(
                name: "oturma");

            migrationBuilder.DropTable(
                name: "oturmafiyat");

            migrationBuilder.DropTable(
                name: "yatma");

            migrationBuilder.DropTable(
                name: "yatmafiyat");

            migrationBuilder.DropTable(
                name: "yemek");

            migrationBuilder.DropTable(
                name: "yemekfiyat");

            migrationBuilder.DropTable(
                name: "Alici");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "prodouct");

            migrationBuilder.DropTable(
                name: "fiyat");

            migrationBuilder.DropTable(
                name: "urun");

            migrationBuilder.DropTable(
                name: "Admenbanal");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

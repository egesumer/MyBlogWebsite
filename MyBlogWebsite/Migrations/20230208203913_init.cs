﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalReadCount = table.Column<int>(type: "int", nullable: true),
                    RequiredMinuteToReadEntireArticle = table.Column<int>(type: "int", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "702d117c-88f5-46d5-9d61-c5b5db3ac108", "2e07863d-17bd-4324-a707-617e4758cece", "admin", "ADMIN" },
                    { "c98aa1ab-13aa-4117-a0a2-7fd83053c91b", "20ac5fcf-5dc6-4672-921a-ffb7dcfc70f8", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4010f570-3cb1-46db-b95a-97374d6f0aec", 0, "244502aa-7c33-4655-a9f1-9efa6319f1c6", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEBJLUx17XFH/sWu71KyNi74ffLNBxB0lx2AG177KVOPUeRoA6cldCPRNz3C49bemgQ==", null, false, "100ca499-854a-4ec5-bf57-07a2e6ffb808", false, "admin" },
                    { "64ddc365-2ea5-4077-9845-acbb91058fd2", 0, "962d56bb-73db-45bc-ad0b-38f2bb195cd8", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEGNVpZt695qdfG15FGgqD1puWRQ+qrkSI7V5Zs2rav6rK54BWK7VfK2QrMCzp6uQxQ==", null, false, "d0c06fd3-7bb6-4868-bc5f-91a06adc38bd", false, "test" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "IsAdmin", "true", "4010f570-3cb1-46db-b95a-97374d6f0aec" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "702d117c-88f5-46d5-9d61-c5b5db3ac108", "4010f570-3cb1-46db-b95a-97374d6f0aec" },
                    { "c98aa1ab-13aa-4117-a0a2-7fd83053c91b", "64ddc365-2ea5-4077-9845-acbb91058fd2" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "ApplicationUserId", "AuthorConfirmed", "AuthorName" },
                values: new object[] { 1, "4010f570-3cb1-46db-b95a-97374d6f0aec", true, "Anasayfa Yazarı" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[] { 1, "Küresel Isınma - Nedenler ve Sonuçları", 1, "Küresel ısınma, Dünya'nın sürekli olarak artan ortalama sıcaklığıdır. Bu sıcaklık artışı, insan aktiviteleri tarafından salınan sera gazlarının atmosferdeki miktarının artmasına bağlıdır.\r\n\r\nSera gazları, güneş ışığının Dünya'ya ulaşmasına izin verirken, aynı zamanda bu ışığın tekrar atmosfer tarafından emilmesini engeller. Böylece, atmosferdeki sera gazları, Dünya'nın sıcaklığını yükseltir.\r\n\r\nİnsan aktiviteleri, sera gazı salınmasını artıran en büyük nedenlerden biridir. Endüstriyel faaliyetler, ulaşım, tarım ve enerji üretimi gibi faaliyetler, CO2 ve diğer sera gazlarının atmosfere salınmasına neden olur.\r\n\r\nKüresel ısınmanın sonuçları ciddi ve uzun vadelidir. Bu sonuçlar arasında; deniz seviyesinin yükselmesi, buzulların erimesi, iklim değişikliği, biyolojik çeşitlilikte azalma ve su kaynaklarının azalması gibi faktörler bulunur.\r\n\r\nDünya çapında, küresel ısınma konusunda acil bir müdahale gerekmektedir. İnsanlar, sera gazı salınmasını azaltmak için sürdürülebilir enerji kaynaklarına yönelmeli ve enerji verimliliğini artırmalıdır. Ayrıca, ülkeler arasında küresel ısınmaya karşı ortak bir mücadele başlatılması gerekmektedir.", new DateTime(2023, 2, 8, 23, 39, 13, 736, DateTimeKind.Local).AddTicks(431), 2, 5 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[] { 2, "İstanbul Sanayi - Türkiye ve Dünya Ekonomisi İçin Önemli Bir Merkez", 1, "İstanbul, Türkiye'nin en büyük ve en kalabalık şehridir ve sanayi açısından da oldukça önemlidir. İstanbul sanayi, Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlar.\r\n\r\nİstanbul'da bulunan sanayi tesisleri, çeşitli sektörlerde üretim yapmaktadır. Bunlar arasında metalürji, tekstil, gıda, elektronik, petrokimya gibi sektörler bulunmaktadır. Bu sektörler, Türkiye ekonomisi için hayati önem taşır ve İstanbul sanayi, bu sektörlerin önemli bir merkezidir.\r\n\r\nİstanbul sanayi, aynı zamanda Türkiye'nin dış ticaretini de destekler. İstanbul limanı, Türkiye'nin en büyük ve en önemli limanıdır ve bu liman, İstanbul sanayi için de önemlidir. İstanbul sanayi ürünleri, dünya çapında ihracat yapılmasını mümkün kılar.\r\n\r\nSonuç olarak, İstanbul sanayi, Türkiye ve dünya ekonomisi için önemli bir merkezdir. İstanbul sanayi, Türkiye ekonomisi için hayati önem taşır ve dünya çapında üretim ve ihracat yapılmasını mümkün kılar. İstanbul sanayi, gelecekte de Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlamaya devam edecektir.", new DateTime(2023, 2, 8, 23, 39, 13, 736, DateTimeKind.Local).AddTicks(433), 2, 5 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[] { 3, "Geridönüşüm - Hayatımız ve Dünyamız İçin Önemli Bir Adım", 1, "Geridönüşüm, atık materyallerin tekrar kullanılması veya işlenerek farklı bir ürüne dönüştürülmesidir. Bu süreç, çevresel açıdan faydalıdır çünkü atıkların depolanması veya yok edilmesi yerine tekrar kullanılması sayesinde çevresel sorunları azaltır.\r\n\r\nAyrıca, geridönüşüm, ekonomik açıdan da avantajlıdır. Geridönüştürülen materyallerin üretimi, yeni materyal üretiminden daha düşük enerji ve kaynak gerektirir. Böylece, enerji tasarrufu sağlanır ve doğal kaynaklar korunur.\r\n\r\nHerkesin katkıda bulunabileceği bir konu olan geridönüşüm, evlerimizden başlayarak uygulanabilir. Atıkları sınıflandırarak, geri dönüştürülebilir materyalleri ayrı tutmak, çevresel ve ekonomik açıdan faydalıdır.\r\n\r\nSonuç olarak, geridönüşüm, hayatımız ve dünyamız için önemli bir adımdır. Herkesin katkıda bulunabileceği bu süreç, çevresel ve ekonomik açıdan faydalı olduğu kadar, gelecek nesillere daha temiz ve daha sağlıklı bir dünya bırakmak için de önemlidir. Üstelik, geridönüşüm yapmak kolaydır ve her yaşta herkes tarafından uygulanabilir. Bugünden başlayarak, atıklarımızı geridönüştürerek, dünyamızın geleceğine katkıda bulunabiliriz.", new DateTime(2023, 2, 8, 23, 39, 13, 736, DateTimeKind.Local).AddTicks(435), 2, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

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
                name: "IX_Authors_ApplicationUserId",
                table: "Authors",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

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
                name: "Authors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
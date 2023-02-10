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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e75537c-7c00-4a8f-943f-91a6f301c831", "422f0335-631d-4b69-a357-1782bcb4a5ee", "standard", "STANDARD" },
                    { "e7209cf8-2023-44e0-928b-bc21ca8c573d", "c42df8a1-0e79-403e-8a5d-0ed251463a0b", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "301eead4-7b50-4aec-b40a-eb2aa4741d34", 0, "43451e8a-0bfe-4dd8-94bc-799b716e7b6c", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEGDSjHrXLQhn0fDiQS3dPQt7vIsL52rLrVMcr1A/ahhSoRBL90AQkNOS7gJ/0GPg2w==", null, false, "8e4935c6-8341-4557-bace-9010b85d4f27", false, "test" },
                    { "bdaf1788-587c-419b-9532-5b6adad993b1", 0, "5c4f47f2-22dd-4ca9-9b99-b4a43a7f706e", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEBhiUM8J0/25b0P0rz1Ow/8/lUy8pGQoRgPjt00wQpxY2laFQm5oudMpz6szyhUT7A==", null, false, "48bb9e6c-4472-4227-a384-cb8b0030b94f", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Adalet" },
                    { 2, "Bilim" },
                    { 3, "Çevre" },
                    { 4, "Dünya" },
                    { 5, "Ekonomi" },
                    { 6, "Enerji" },
                    { 7, "Finans" },
                    { 8, "Genetik" },
                    { 9, "Haberleşme" },
                    { 10, "İnsanlar" },
                    { 11, "Kültür" },
                    { 12, "Sanat" },
                    { 13, "Sağlık" },
                    { 14, "Teknoloji" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "IsAdmin", "true", "bdaf1788-587c-419b-9532-5b6adad993b1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9e75537c-7c00-4a8f-943f-91a6f301c831", "301eead4-7b50-4aec-b40a-eb2aa4741d34" },
                    { "e7209cf8-2023-44e0-928b-bc21ca8c573d", "bdaf1788-587c-419b-9532-5b6adad993b1" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "ApplicationUserId", "AuthorConfirmed", "AuthorName" },
                values: new object[] { 1, "bdaf1788-587c-419b-9532-5b6adad993b1", true, "Anasayfa Yazarı" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "CategoryId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[] { 1, "Küresel Isınma - Nedenler ve Sonuçları", 1, 4, "Küresel ısınma, Dünya'nın sürekli olarak artan ortalama sıcaklığıdır. Bu sıcaklık artışı, insan aktiviteleri tarafından salınan sera gazlarının atmosferdeki miktarının artmasına bağlıdır.\r\n\r\nSera gazları, güneş ışığının Dünya'ya ulaşmasına izin verirken, aynı zamanda bu ışığın tekrar atmosfer tarafından emilmesini engeller. Böylece, atmosferdeki sera gazları, Dünya'nın sıcaklığını yükseltir.\r\n\r\nİnsan aktiviteleri, sera gazı salınmasını artıran en büyük nedenlerden biridir. Endüstriyel faaliyetler, ulaşım, tarım ve enerji üretimi gibi faaliyetler, CO2 ve diğer sera gazlarının atmosfere salınmasına neden olur.\r\n\r\nKüresel ısınmanın sonuçları ciddi ve uzun vadelidir. Bu sonuçlar arasında; deniz seviyesinin yükselmesi, buzulların erimesi, iklim değişikliği, biyolojik çeşitlilikte azalma ve su kaynaklarının azalması gibi faktörler bulunur.\r\n\r\nDünya çapında, küresel ısınma konusunda acil bir müdahale gerekmektedir. İnsanlar, sera gazı salınmasını azaltmak için sürdürülebilir enerji kaynaklarına yönelmeli ve enerji verimliliğini artırmalıdır. Ayrıca, ülkeler arasında küresel ısınmaya karşı ortak bir mücadele başlatılması gerekmektedir.", new DateTime(2023, 2, 10, 1, 13, 7, 42, DateTimeKind.Local).AddTicks(7697), 2, 5 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "CategoryId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[] { 2, "İstanbul Sanayi - Türkiye ve Dünya Ekonomisi İçin Önemli Bir Merkez", 1, 5, "İstanbul, Türkiye'nin en büyük ve en kalabalık şehridir ve sanayi açısından da oldukça önemlidir. İstanbul sanayi, Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlar.\r\n\r\nİstanbul'da bulunan sanayi tesisleri, çeşitli sektörlerde üretim yapmaktadır. Bunlar arasında metalürji, tekstil, gıda, elektronik, petrokimya gibi sektörler bulunmaktadır. Bu sektörler, Türkiye ekonomisi için hayati önem taşır ve İstanbul sanayi, bu sektörlerin önemli bir merkezidir.\r\n\r\nİstanbul sanayi, aynı zamanda Türkiye'nin dış ticaretini de destekler. İstanbul limanı, Türkiye'nin en büyük ve en önemli limanıdır ve bu liman, İstanbul sanayi için de önemlidir. İstanbul sanayi ürünleri, dünya çapında ihracat yapılmasını mümkün kılar.\r\n\r\nSonuç olarak, İstanbul sanayi, Türkiye ve dünya ekonomisi için önemli bir merkezdir. İstanbul sanayi, Türkiye ekonomisi için hayati önem taşır ve dünya çapında üretim ve ihracat yapılmasını mümkün kılar. İstanbul sanayi, gelecekte de Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlamaya devam edecektir.", new DateTime(2023, 2, 10, 1, 13, 7, 42, DateTimeKind.Local).AddTicks(7700), 2, 5 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "CategoryId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[] { 3, "Geridönüşüm - Hayatımız ve Dünyamız İçin Önemli Bir Adım", 1, 3, "Geridönüşüm, atık materyallerin tekrar kullanılması veya işlenerek farklı bir ürüne dönüştürülmesidir. Bu süreç, çevresel açıdan faydalıdır çünkü atıkların depolanması veya yok edilmesi yerine tekrar kullanılması sayesinde çevresel sorunları azaltır.\r\n\r\nAyrıca, geridönüşüm, ekonomik açıdan da avantajlıdır. Geridönüştürülen materyallerin üretimi, yeni materyal üretiminden daha düşük enerji ve kaynak gerektirir. Böylece, enerji tasarrufu sağlanır ve doğal kaynaklar korunur.\r\n\r\nHerkesin katkıda bulunabileceği bir konu olan geridönüşüm, evlerimizden başlayarak uygulanabilir. Atıkları sınıflandırarak, geri dönüştürülebilir materyalleri ayrı tutmak, çevresel ve ekonomik açıdan faydalıdır.\r\n\r\nSonuç olarak, geridönüşüm, hayatımız ve dünyamız için önemli bir adımdır. Herkesin katkıda bulunabileceği bu süreç, çevresel ve ekonomik açıdan faydalı olduğu kadar, gelecek nesillere daha temiz ve daha sağlıklı bir dünya bırakmak için de önemlidir. Üstelik, geridönüşüm yapmak kolaydır ve her yaşta herkes tarafından uygulanabilir. Bugünden başlayarak, atıklarımızı geridönüştürerek, dünyamızın geleceğine katkıda bulunabiliriz.", new DateTime(2023, 2, 10, 1, 13, 7, 42, DateTimeKind.Local).AddTicks(7702), 2, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
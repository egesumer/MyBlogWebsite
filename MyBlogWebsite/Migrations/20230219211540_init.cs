using System;
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
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "AuthorCategory",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    FavoryCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorCategory", x => new { x.AuthorsId, x.FavoryCategoriesId });
                    table.ForeignKey(
                        name: "FK_AuthorCategory_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorCategory_Categories_FavoryCategoriesId",
                        column: x => x.FavoryCategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c5732985-5b81-412f-80cd-1ce99d2d260a", "e0cf652e-850e-472e-9902-de7af2ad2ccd", "admin", "ADMIN" },
                    { "c9d5502b-cafb-43bb-93dd-e1824daadc66", "e11fb80c-8a7c-4dc8-9986-9abad5944f2b", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "aa4d3a9a-10c5-4baf-ad97-69663b0d0274", 0, "a1cc29ec-cad2-4668-b480-86ea023f0dfb", "ApplicationUser", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEC5L5R6mmyfXGBVz3/yIjbKGpsgzxb9FG6anJl3H+5clbHQTeA2HsQ37qjACr41TUQ==", null, false, "81f10150-e1d2-4a4f-9e6f-01ff4bd382b0", false, "admin" },
                    { "ea5f5766-fd3c-4d20-aac4-b8cc9753d2ef", 0, "756c0aa2-16c7-48c2-bf5f-6eeca53fab83", "ApplicationUser", "test@test.com", true, "testName", "testLastName", false, null, "TEST@TEST.COM", "TEST", "AQAAAAEAACcQAAAAEBS8JHf5/8CytGF5f94G59+qM76cCg7Cz1VDXeVvEKXDfXWm/vrV3bQDQxG9rQ7ZOA==", null, false, "f049699e-87ec-4134-85c9-2ebec9a4c647", false, "test" }
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
                values: new object[] { 1, "IsAdmin", "true", "aa4d3a9a-10c5-4baf-ad97-69663b0d0274" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c5732985-5b81-412f-80cd-1ce99d2d260a", "aa4d3a9a-10c5-4baf-ad97-69663b0d0274" },
                    { "c9d5502b-cafb-43bb-93dd-e1824daadc66", "ea5f5766-fd3c-4d20-aac4-b8cc9753d2ef" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AboutMe", "ApplicationUserId", "AuthorConfirmed", "AuthorName", "Photo" },
                values: new object[] { 1, "Merhaba, ben kurucu yazarım.", "aa4d3a9a-10c5-4baf-ad97-69663b0d0274", true, "Anasayfa Yazarı", null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleTitle", "AuthorId", "CategoryId", "Content", "PublishDate", "RequiredMinuteToReadEntireArticle", "TotalReadCount" },
                values: new object[,]
                {
                    { 1, "Küresel Isınma - Nedenler ve Sonuçları", 1, 4, "Küresel ısınma, Dünya'nın sürekli olarak artan ortalama sıcaklığıdır. Bu sıcaklık artışı, insan aktiviteleri tarafından salınan sera gazlarının atmosferdeki miktarının artmasına bağlıdır.\r\n\r\nSera gazları, güneş ışığının Dünya'ya ulaşmasına izin verirken, aynı zamanda bu ışığın tekrar atmosfer tarafından emilmesini engeller. Böylece, atmosferdeki sera gazları, Dünya'nın sıcaklığını yükseltir.\r\n\r\nİnsan aktiviteleri, sera gazı salınmasını artıran en büyük nedenlerden biridir. Endüstriyel faaliyetler, ulaşım, tarım ve enerji üretimi gibi faaliyetler, CO2 ve diğer sera gazlarının atmosfere salınmasına neden olur.\r\n\r\nKüresel ısınmanın sonuçları ciddi ve uzun vadelidir. Bu sonuçlar arasında; deniz seviyesinin yükselmesi, buzulların erimesi, iklim değişikliği, biyolojik çeşitlilikte azalma ve su kaynaklarının azalması gibi faktörler bulunur.\r\n\r\nDünya çapında, küresel ısınma konusunda acil bir müdahale gerekmektedir. İnsanlar, sera gazı salınmasını azaltmak için sürdürülebilir enerji kaynaklarına yönelmeli ve enerji verimliliğini artırmalıdır. Ayrıca, ülkeler arasında küresel ısınmaya karşı ortak bir mücadele başlatılması gerekmektedir.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7743), 2, 5 },
                    { 2, "İstanbul Sanayi - Türkiye ve Dünya Ekonomisi İçin Önemli Bir Merkez", 1, 5, "İstanbul, Türkiye'nin en büyük ve en kalabalık şehridir ve sanayi açısından da oldukça önemlidir. İstanbul sanayi, Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlar.\r\n\r\nİstanbul'da bulunan sanayi tesisleri, çeşitli sektörlerde üretim yapmaktadır. Bunlar arasında metalürji, tekstil, gıda, elektronik, petrokimya gibi sektörler bulunmaktadır. Bu sektörler, Türkiye ekonomisi için hayati önem taşır ve İstanbul sanayi, bu sektörlerin önemli bir merkezidir.\r\n\r\nİstanbul sanayi, aynı zamanda Türkiye'nin dış ticaretini de destekler. İstanbul limanı, Türkiye'nin en büyük ve en önemli limanıdır ve bu liman, İstanbul sanayi için de önemlidir. İstanbul sanayi ürünleri, dünya çapında ihracat yapılmasını mümkün kılar.\r\n\r\nSonuç olarak, İstanbul sanayi, Türkiye ve dünya ekonomisi için önemli bir merkezdir. İstanbul sanayi, Türkiye ekonomisi için hayati önem taşır ve dünya çapında üretim ve ihracat yapılmasını mümkün kılar. İstanbul sanayi, gelecekte de Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlamaya devam edecektir.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7745), 2, 5 },
                    { 3, "Geridönüşüm - Hayatımız ve Dünyamız İçin Önemli Bir Adım", 1, 3, "Geridönüşüm, atık materyallerin tekrar kullanılması veya işlenerek farklı bir ürüne dönüştürülmesidir. Bu süreç, çevresel açıdan faydalıdır çünkü atıkların depolanması veya yok edilmesi yerine tekrar kullanılması sayesinde çevresel sorunları azaltır.\r\n\r\nAyrıca, geridönüşüm, ekonomik açıdan da avantajlıdır. Geridönüştürülen materyallerin üretimi, yeni materyal üretiminden daha düşük enerji ve kaynak gerektirir. Böylece, enerji tasarrufu sağlanır ve doğal kaynaklar korunur.\r\n\r\nHerkesin katkıda bulunabileceği bir konu olan geridönüşüm, evlerimizden başlayarak uygulanabilir. Atıkları sınıflandırarak, geri dönüştürülebilir materyalleri ayrı tutmak, çevresel ve ekonomik açıdan faydalıdır.\r\n\r\nSonuç olarak, geridönüşüm, hayatımız ve dünyamız için önemli bir adımdır. Herkesin katkıda bulunabileceği bu süreç, çevresel ve ekonomik açıdan faydalı olduğu kadar, gelecek nesillere daha temiz ve daha sağlıklı bir dünya bırakmak için de önemlidir. Üstelik, geridönüşüm yapmak kolaydır ve her yaşta herkes tarafından uygulanabilir. Bugünden başlayarak, atıklarımızı geridönüştürerek, dünyamızın geleceğine katkıda bulunabiliriz.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7747), 2, 5 },
                    { 4, "Türkiye Ekonomisi", 1, 7, "Türkiye’nin küresel dalgalanmalardan en çok etkilenen ülkelerden biri olması nedeniyle en önemli gündemini ekonomi oluşturmaktadır. 2000’li yıllarda yaşanan küresel krizlerin etkisiyle daralan Türkiye ekonomisi, takip eden yıllarda iyileşme sürecine girse de genel olarak olası dış şoklara karşı kırılgan yapısını sürdürmektedir. Türkiye ekonomisinin bu kırılgan yapısının temel nedenini aslında 24 Ocak 1980 kararlarıyla birlikte uygulamaya geçirilen yapısal uyum politikaları oluşturmaktadır. Yapısal uyum politikaları ile Türkiye ekonomisinde dışa dönük ve ihracata dayalı sanayileşme stratejileri uygulanmış böylece ithal ikameci politikalarla dış ticaret baskı altına alınmıştır.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7749), 2, 5 },
                    { 5, "Adalet Nedir?", 1, 1, "Öncelikle adalet, karşılıklı insan ilişkilerini düzenleyen toplumsal\r\ndüzenin mümkün, ama zorunlu olmayan bir niteliğidir. O, ancak tali\r\nolarak insanın bir erdemidir; çünkü insan, eğer davranışı adil olarak\r\nkabul edilen toplumsal bir düzenin normlarına uyuyorsa adildir. Peki,\r\ntoplumsal bir düzenin adil olduğunu söylemek gerçekte ne anlama gelir? O şu demektir: bu (toplumsal) düzen, insan davranışlarını herkesi\r\ntatmin edecek şekilde düzenlemiştir. Yani herkes, o düzende mutluluğu bulabilir. Adalet arzusu, insanın mutluluk için duyduğu ebedi\r\narzudur. O, insanın yalıtılmış bir şekilde, yani yalnız başına bulamayacağı, bu nedenle bir toplum içinde aradığı bir mutluluktur. Yani\r\nadalet, toplumsal mutluluktur. O, toplumsal düzen tarafından garanti\r\nedilmiş bir mutluluktur. Bu bağlamda, adaleti mutluluk olarak tanımlayan Eflatun, sadece adil insanın mutlu ve adil olmayanın da mutsuz\r\nolduğunu ileri sürer. (Ancak) adaletin mutluluk olduğu yönündeki\r\nifade, elbette ki nihai cevap değildir; o, sadece soruyu değiştirmektir.\r\nÇünkü şu halde sormamız gerekir: Mutluluk nedir?\r\n", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7750), 2, 5 },
                    { 6, "Bilimin Esası", 1, 2, "Bilim, en küçük atomaltı parçacıklardan en büyük galaksi kümelerine kadar, fiziksel ve doğal dünyanın yapısını ve davranışlarını gözlem ve deney yoluyla, sistematik bir şekilde inceleyen, entelektüel ve pratik bir faaliyet olarak tanımlanabilir.Bilim, Evren'e, parçalarına ve varsa ötesine dair genel gerçekleri ve temel yasaları öğrenme yolunda çıkılan bir yolculuk; bir veri toplama, değerlendirme ve öngörü aracı olarak da düşünülebilir. Bir diğer deyişle bilim, doğal dünyada olan biteni ve bunların nasıl işlediğini öğrenmenin bir yoludur; bu bakımdan bilim, pul koleksiyonu yapmak gibi gerçekleri toplamaktan ibaret değildir; onları açıklayıp, anlamayı da hedefler", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7752), 2, 5 },
                    { 7, "Küreselleşme ve Enerji Gidişatı", 1, 6, "Küreselleşmeyle birlikte son zamanlarda sanayi alanında gelişmelerin yaşanması, teknolojinin ilerlemesi nüfusun artması gibi birçok sebep enerji kaynaklarının kullanımını hızla arttırmaktadır. Sınırlı olarak bulunan fosil yakıtlarının gelecek dönemlerde yetersiz olacağı bilinmektedir. Aynı zamanda dünya ülkelerinin bu yakıtları ele geçirme isteği gün geçtikçe artmaktadır. Bunun için Enerji geçmişten günümüze her toplumun önemli sorunlarından birini oluşturmaktadır. Ayrıca enerji kaynaklarının bilinçsizce kullanılması ve mevcut kaynakların hızla tükenmesi sonucu insanlar farklı enerji kaynağı arayışına girmektedir. Hali hazırda kullanılan fosil yakıtların ömrünün azalması aynı zamanda çevreye ve insan sağlığına olumsuz etkisi ülkelerin yenilenebilir enerji kaynaklarına yönelmesine sebep olmaktadır. Güneş, jeotermal, rüzgar, biyokütle, dalga enerjisi gibi yenilenebilir enerji kaynakları son dönemlerde ülkeler tarafından tercih edilen alternatif enerji kaynaklarıdır. Bu çalışmada hem dünyanın hem de Türkiye’ nin enerji kaynaklarını tüketme payları incelenmekte ve buna bağlı olarak alternatif enerji kaynaklarının gerekliliği üzerinde durulmaktadır. Aynı zamanda Türkiye’ de yenilenebilir enerji kaynaklarının mevcut kapasiteleri ve potansiyelleri üzerine bir değerlendirme yapılmaktadır.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7754), 2, 5 },
                    { 8, "Genetiğin Tarihi ve Gelişimi", 1, 8, "Genetik ya da kalıtım bilimi, biyolojinin organizmalardaki kalıtım ve genetik varyasyonu inceleyen bir dalıdır.Türkçeye Almancadan geçen genetik sözcüğü 1831 yılında Yunanca γενετικός - genetikos (\"genitif\") sözcüğünden türetildi. Bu sözcüğün kökeni ise γένεσις - genesis (\"köken\") sözcüğüne dayanmaktadır.\r\n\r\nCanlıların özelliklerinin kalıtsal olduğunun bilinci ile tarih öncesi çağlardan beri bitki ve hayvanlar ıslah edilmiştir. Bununla birlikte, kalıtımsal aktarım mekanizmalarını anlamaya çalışan modern genetik bilimi ancak 19. yüzyılın ortalarında, Gregor Mendel’in çalışmasıyla başlamıştır. Mendel, kalıtımın fiziksel temelini bilemediyse de, bu özelliklerin ayrık (kesikli) bir tarzda aktarıldığını gözlemlemiştir; günümüzde bu kalıtım birimlerine \"gen\" adı verilmektedir.\r\n\r\nGenler DNA'da belli bölgelere karşılık gelir. DNA dört tip nükleotitten oluşan bir zincir moleküldür. Bu zincir üzerinde nükleotitlerin dizisi, organizmaların kalıt aldığı genetik bilgidir (enformasyon). Doğada DNA, iki zincirli bir yapıya sahiptir. DNA'daki her \"iplikçik\"teki nükleotitler birbirini tamamlar, yani her iplikçik, kendine eş yeni bir iplikçik oluşturmak için bir kalıp olabilme özelliğine sahiptir. Bu, genetik bilginin kopyalanması ve kalıtımı için işleyen fiziksel mekanizmadır.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7755), 2, 5 },
                    { 9, "İnsanlığın Gelişimi", 1, 10, "İnsanlık tarihi, insanlığın geçmişinin tasviridir. Arkeoloji, antropoloji, genetik, dilbilim, epigrafi, filoloji, paleografi ve diğer disiplinler ile yazının icadından bu yana, kayıtlı tarih, ikincil kaynaklar ve araştırmalar yoluyla incelenir.\r\n\r\nİnsanlık tarihi, Paleolitik Çağ'dan (Eski Taş Devri) başlayıp, ardından Neolitik Çağ'ın (Cilalı Taş Devri) takip ettiği tarih öncesine dayanıyordu. Neolitik Çağ, Yakın Doğu'nun Bereketli Hilal'inde, tarım devriminin MÖ 10.000 ila 5.000 yılları arasında başladığına tanık oldu. Bu dönemde insanlar sistematik bitki ve hayvan yetiştiriciliğine başladı.[1] Tarım ilerledikçe çoğu insan, göçebelikten yerleşik bir yaşam tarzına geçiş yaptı ve genellikle çiftçi olarak kalıcı yerleşkelerde yaşamaya başladı. Çiftçiliğin sağladığı göreceli güvenlik ve artan üretkenlik, insan toplulukların ulaşımdaki gelişmelerle birlikte giderek daha büyük birimlere genişlemesini sağladı.", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7757), 2, 5 },
                    { 10, "Bluetooth Nedir?", 1, 9, "Bluetooth, sabit veya taşınabilir cihazlar arasında kısa mesafelerde veri aktarımı yapmaya veya kişisel alan ağları (PAN) kurmaya yarayan kablosuz bağlantı standardı.2,02 GHz ile 2,48 GHz aralığındaki ISM bantlarında UHF radyo dalgalarını kullanır. Genellikle kablolu bağlantılara alternatif olarak, birbirine yakın taşınabilir cihazlar arasında dosya alışverişi yapmak ve müzikçalarlar ile kablosuz kulaklıkları birbirine bağlamak için kullanılır. En sık kullanılan modunda aktarım gücü 2,4 miliwatt ile sınırlı olduğu için kapsama alanı 10 metreyi geçemez.\r\n\r\nBluetooth standardı Bluetooth Special Interest Group (SIG) tarafından yönetilir. Telekomünikasyon, bilgi işlem, ağ ürünleri ve tüketici elektroniği alanlarında 35.000'den fazla şirket gruba üyedir. IEEE, Bluetooth'u IEEE 802.15.1 olarak standartlaştırmış olmasına rağmen artık bu standart üzerinde çalışmamaktadır. ", new DateTime(2023, 2, 20, 0, 15, 39, 938, DateTimeKind.Local).AddTicks(7815), 2, 5 }
                });

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
                name: "IX_AuthorCategory_FavoryCategoriesId",
                table: "AuthorCategory",
                column: "FavoryCategoriesId");

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
                name: "AuthorCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

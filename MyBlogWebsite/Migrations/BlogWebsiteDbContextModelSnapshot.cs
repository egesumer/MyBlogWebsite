﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlogWebsite.Areas.Identity.Data;

#nullable disable

namespace MyBlogWebsite.Migrations
{
    [DbContext(typeof(BlogWebsiteDbContext))]
    partial class BlogWebsiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorCategory", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("FavoryCategoriesId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "FavoryCategoriesId");

                    b.HasIndex("FavoryCategoriesId");

                    b.ToTable("AuthorCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cb957cd6-0022-4332-83e3-8d91fd5d4990",
                            ConcurrencyStamp = "907ae2aa-b2fa-4657-99d5-c7e52c0775cc",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "51005909-6d79-45a9-a16f-8808be4c0213",
                            ConcurrencyStamp = "a5e24b64-a30d-45a7-b201-80c281d7991c",
                            Name = "standard",
                            NormalizedName = "STANDARD"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "IsAdmin",
                            ClaimValue = "true",
                            UserId = "dea11798-f61f-44c5-bc5f-324a314e12d1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dea11798-f61f-44c5-bc5f-324a314e12d1",
                            RoleId = "cb957cd6-0022-4332-83e3-8d91fd5d4990"
                        },
                        new
                        {
                            UserId = "6ddc7555-5116-45a6-ae6f-fc2291f2d00c",
                            RoleId = "51005909-6d79-45a9-a16f-8808be4c0213"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArticleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequiredMinuteToReadEntireArticle")
                        .HasColumnType("int");

                    b.Property<int?>("TotalReadCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleTitle = "Küresel Isınma - Nedenler ve Sonuçları",
                            AuthorId = 1,
                            CategoryId = 4,
                            Content = "Küresel ısınma, Dünya'nın sürekli olarak artan ortalama sıcaklığıdır. Bu sıcaklık artışı, insan aktiviteleri tarafından salınan sera gazlarının atmosferdeki miktarının artmasına bağlıdır.\r\n\r\nSera gazları, güneş ışığının Dünya'ya ulaşmasına izin verirken, aynı zamanda bu ışığın tekrar atmosfer tarafından emilmesini engeller. Böylece, atmosferdeki sera gazları, Dünya'nın sıcaklığını yükseltir.\r\n\r\nİnsan aktiviteleri, sera gazı salınmasını artıran en büyük nedenlerden biridir. Endüstriyel faaliyetler, ulaşım, tarım ve enerji üretimi gibi faaliyetler, CO2 ve diğer sera gazlarının atmosfere salınmasına neden olur.\r\n\r\nKüresel ısınmanın sonuçları ciddi ve uzun vadelidir. Bu sonuçlar arasında; deniz seviyesinin yükselmesi, buzulların erimesi, iklim değişikliği, biyolojik çeşitlilikte azalma ve su kaynaklarının azalması gibi faktörler bulunur.\r\n\r\nDünya çapında, küresel ısınma konusunda acil bir müdahale gerekmektedir. İnsanlar, sera gazı salınmasını azaltmak için sürdürülebilir enerji kaynaklarına yönelmeli ve enerji verimliliğini artırmalıdır. Ayrıca, ülkeler arasında küresel ısınmaya karşı ortak bir mücadele başlatılması gerekmektedir.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3627),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 2,
                            ArticleTitle = "İstanbul Sanayi - Türkiye ve Dünya Ekonomisi İçin Önemli Bir Merkez",
                            AuthorId = 1,
                            CategoryId = 5,
                            Content = "İstanbul, Türkiye'nin en büyük ve en kalabalık şehridir ve sanayi açısından da oldukça önemlidir. İstanbul sanayi, Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlar.\r\n\r\nİstanbul'da bulunan sanayi tesisleri, çeşitli sektörlerde üretim yapmaktadır. Bunlar arasında metalürji, tekstil, gıda, elektronik, petrokimya gibi sektörler bulunmaktadır. Bu sektörler, Türkiye ekonomisi için hayati önem taşır ve İstanbul sanayi, bu sektörlerin önemli bir merkezidir.\r\n\r\nİstanbul sanayi, aynı zamanda Türkiye'nin dış ticaretini de destekler. İstanbul limanı, Türkiye'nin en büyük ve en önemli limanıdır ve bu liman, İstanbul sanayi için de önemlidir. İstanbul sanayi ürünleri, dünya çapında ihracat yapılmasını mümkün kılar.\r\n\r\nSonuç olarak, İstanbul sanayi, Türkiye ve dünya ekonomisi için önemli bir merkezdir. İstanbul sanayi, Türkiye ekonomisi için hayati önem taşır ve dünya çapında üretim ve ihracat yapılmasını mümkün kılar. İstanbul sanayi, gelecekte de Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlamaya devam edecektir.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3630),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 3,
                            ArticleTitle = "Geridönüşüm - Hayatımız ve Dünyamız İçin Önemli Bir Adım",
                            AuthorId = 1,
                            CategoryId = 3,
                            Content = "Geridönüşüm, atık materyallerin tekrar kullanılması veya işlenerek farklı bir ürüne dönüştürülmesidir. Bu süreç, çevresel açıdan faydalıdır çünkü atıkların depolanması veya yok edilmesi yerine tekrar kullanılması sayesinde çevresel sorunları azaltır.\r\n\r\nAyrıca, geridönüşüm, ekonomik açıdan da avantajlıdır. Geridönüştürülen materyallerin üretimi, yeni materyal üretiminden daha düşük enerji ve kaynak gerektirir. Böylece, enerji tasarrufu sağlanır ve doğal kaynaklar korunur.\r\n\r\nHerkesin katkıda bulunabileceği bir konu olan geridönüşüm, evlerimizden başlayarak uygulanabilir. Atıkları sınıflandırarak, geri dönüştürülebilir materyalleri ayrı tutmak, çevresel ve ekonomik açıdan faydalıdır.\r\n\r\nSonuç olarak, geridönüşüm, hayatımız ve dünyamız için önemli bir adımdır. Herkesin katkıda bulunabileceği bu süreç, çevresel ve ekonomik açıdan faydalı olduğu kadar, gelecek nesillere daha temiz ve daha sağlıklı bir dünya bırakmak için de önemlidir. Üstelik, geridönüşüm yapmak kolaydır ve her yaşta herkes tarafından uygulanabilir. Bugünden başlayarak, atıklarımızı geridönüştürerek, dünyamızın geleceğine katkıda bulunabiliriz.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3632),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 4,
                            ArticleTitle = "Türkiye Ekonomisi",
                            AuthorId = 1,
                            CategoryId = 3,
                            Content = "Türkiye’nin küresel dalgalanmalardan en çok etkilenen ülkelerden biri olması nedeniyle en önemli gündemini ekonomi oluşturmaktadır. 2000’li yıllarda yaşanan küresel krizlerin etkisiyle daralan Türkiye ekonomisi, takip eden yıllarda iyileşme sürecine girse de genel olarak olası dış şoklara karşı kırılgan yapısını sürdürmektedir. Türkiye ekonomisinin bu kırılgan yapısının temel nedenini aslında 24 Ocak 1980 kararlarıyla birlikte uygulamaya geçirilen yapısal uyum politikaları oluşturmaktadır. Yapısal uyum politikaları ile Türkiye ekonomisinde dışa dönük ve ihracata dayalı sanayileşme stratejileri uygulanmış böylece ithal ikameci politikalarla dış ticaret baskı altına alınmıştır.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3633),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 7
                        },
                        new
                        {
                            Id = 5,
                            ArticleTitle = "Adalet Nedir?",
                            AuthorId = 1,
                            CategoryId = 1,
                            Content = "Öncelikle adalet, karşılıklı insan ilişkilerini düzenleyen toplumsal\r\ndüzenin mümkün, ama zorunlu olmayan bir niteliğidir. O, ancak tali\r\nolarak insanın bir erdemidir; çünkü insan, eğer davranışı adil olarak\r\nkabul edilen toplumsal bir düzenin normlarına uyuyorsa adildir. Peki,\r\ntoplumsal bir düzenin adil olduğunu söylemek gerçekte ne anlama gelir? O şu demektir: bu (toplumsal) düzen, insan davranışlarını herkesi\r\ntatmin edecek şekilde düzenlemiştir. Yani herkes, o düzende mutluluğu bulabilir. Adalet arzusu, insanın mutluluk için duyduğu ebedi\r\narzudur. O, insanın yalıtılmış bir şekilde, yani yalnız başına bulamayacağı, bu nedenle bir toplum içinde aradığı bir mutluluktur. Yani\r\nadalet, toplumsal mutluluktur. O, toplumsal düzen tarafından garanti\r\nedilmiş bir mutluluktur. Bu bağlamda, adaleti mutluluk olarak tanımlayan Eflatun, sadece adil insanın mutlu ve adil olmayanın da mutsuz\r\nolduğunu ileri sürer. (Ancak) adaletin mutluluk olduğu yönündeki\r\nifade, elbette ki nihai cevap değildir; o, sadece soruyu değiştirmektir.\r\nÇünkü şu halde sormamız gerekir: Mutluluk nedir?\r\n",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3635),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 6,
                            ArticleTitle = "Bilimin Esası",
                            AuthorId = 1,
                            CategoryId = 2,
                            Content = "Bilim, en küçük atomaltı parçacıklardan en büyük galaksi kümelerine kadar, fiziksel ve doğal dünyanın yapısını ve davranışlarını gözlem ve deney yoluyla, sistematik bir şekilde inceleyen, entelektüel ve pratik bir faaliyet olarak tanımlanabilir.Bilim, Evren'e, parçalarına ve varsa ötesine dair genel gerçekleri ve temel yasaları öğrenme yolunda çıkılan bir yolculuk; bir veri toplama, değerlendirme ve öngörü aracı olarak da düşünülebilir. Bir diğer deyişle bilim, doğal dünyada olan biteni ve bunların nasıl işlediğini öğrenmenin bir yoludur; bu bakımdan bilim, pul koleksiyonu yapmak gibi gerçekleri toplamaktan ibaret değildir; onları açıklayıp, anlamayı da hedefler",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3637),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 7,
                            ArticleTitle = "Küreselleşme ve Enerji Gidişatı",
                            AuthorId = 1,
                            CategoryId = 6,
                            Content = "Küreselleşmeyle birlikte son zamanlarda sanayi alanında gelişmelerin yaşanması, teknolojinin ilerlemesi nüfusun artması gibi birçok sebep enerji kaynaklarının kullanımını hızla arttırmaktadır. Sınırlı olarak bulunan fosil yakıtlarının gelecek dönemlerde yetersiz olacağı bilinmektedir. Aynı zamanda dünya ülkelerinin bu yakıtları ele geçirme isteği gün geçtikçe artmaktadır. Bunun için Enerji geçmişten günümüze her toplumun önemli sorunlarından birini oluşturmaktadır. Ayrıca enerji kaynaklarının bilinçsizce kullanılması ve mevcut kaynakların hızla tükenmesi sonucu insanlar farklı enerji kaynağı arayışına girmektedir. Hali hazırda kullanılan fosil yakıtların ömrünün azalması aynı zamanda çevreye ve insan sağlığına olumsuz etkisi ülkelerin yenilenebilir enerji kaynaklarına yönelmesine sebep olmaktadır. Güneş, jeotermal, rüzgar, biyokütle, dalga enerjisi gibi yenilenebilir enerji kaynakları son dönemlerde ülkeler tarafından tercih edilen alternatif enerji kaynaklarıdır. Bu çalışmada hem dünyanın hem de Türkiye’ nin enerji kaynaklarını tüketme payları incelenmekte ve buna bağlı olarak alternatif enerji kaynaklarının gerekliliği üzerinde durulmaktadır. Aynı zamanda Türkiye’ de yenilenebilir enerji kaynaklarının mevcut kapasiteleri ve potansiyelleri üzerine bir değerlendirme yapılmaktadır.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3639),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 8,
                            ArticleTitle = "Genetiğin Tarihi ve Gelişimi",
                            AuthorId = 1,
                            CategoryId = 8,
                            Content = "Genetik ya da kalıtım bilimi, biyolojinin organizmalardaki kalıtım ve genetik varyasyonu inceleyen bir dalıdır.Türkçeye Almancadan geçen genetik sözcüğü 1831 yılında Yunanca γενετικός - genetikos (\"genitif\") sözcüğünden türetildi. Bu sözcüğün kökeni ise γένεσις - genesis (\"köken\") sözcüğüne dayanmaktadır.\r\n\r\nCanlıların özelliklerinin kalıtsal olduğunun bilinci ile tarih öncesi çağlardan beri bitki ve hayvanlar ıslah edilmiştir. Bununla birlikte, kalıtımsal aktarım mekanizmalarını anlamaya çalışan modern genetik bilimi ancak 19. yüzyılın ortalarında, Gregor Mendel’in çalışmasıyla başlamıştır. Mendel, kalıtımın fiziksel temelini bilemediyse de, bu özelliklerin ayrık (kesikli) bir tarzda aktarıldığını gözlemlemiştir; günümüzde bu kalıtım birimlerine \"gen\" adı verilmektedir.\r\n\r\nGenler DNA'da belli bölgelere karşılık gelir. DNA dört tip nükleotitten oluşan bir zincir moleküldür. Bu zincir üzerinde nükleotitlerin dizisi, organizmaların kalıt aldığı genetik bilgidir (enformasyon). Doğada DNA, iki zincirli bir yapıya sahiptir. DNA'daki her \"iplikçik\"teki nükleotitler birbirini tamamlar, yani her iplikçik, kendine eş yeni bir iplikçik oluşturmak için bir kalıp olabilme özelliğine sahiptir. Bu, genetik bilginin kopyalanması ve kalıtımı için işleyen fiziksel mekanizmadır.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3640),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 9,
                            ArticleTitle = "İnsanlığın Gelişimi",
                            AuthorId = 1,
                            CategoryId = 10,
                            Content = "İnsanlık tarihi, insanlığın geçmişinin tasviridir. Arkeoloji, antropoloji, genetik, dilbilim, epigrafi, filoloji, paleografi ve diğer disiplinler ile yazının icadından bu yana, kayıtlı tarih, ikincil kaynaklar ve araştırmalar yoluyla incelenir.\r\n\r\nİnsanlık tarihi, Paleolitik Çağ'dan (Eski Taş Devri) başlayıp, ardından Neolitik Çağ'ın (Cilalı Taş Devri) takip ettiği tarih öncesine dayanıyordu. Neolitik Çağ, Yakın Doğu'nun Bereketli Hilal'inde, tarım devriminin MÖ 10.000 ila 5.000 yılları arasında başladığına tanık oldu. Bu dönemde insanlar sistematik bitki ve hayvan yetiştiriciliğine başladı.[1] Tarım ilerledikçe çoğu insan, göçebelikten yerleşik bir yaşam tarzına geçiş yaptı ve genellikle çiftçi olarak kalıcı yerleşkelerde yaşamaya başladı. Çiftçiliğin sağladığı göreceli güvenlik ve artan üretkenlik, insan toplulukların ulaşımdaki gelişmelerle birlikte giderek daha büyük birimlere genişlemesini sağladı.",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3642),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        },
                        new
                        {
                            Id = 10,
                            ArticleTitle = "Bluetooth Nedir?",
                            AuthorId = 1,
                            CategoryId = 9,
                            Content = "Bluetooth, sabit veya taşınabilir cihazlar arasında kısa mesafelerde veri aktarımı yapmaya veya kişisel alan ağları (PAN) kurmaya yarayan kablosuz bağlantı standardı.2,02 GHz ile 2,48 GHz aralığındaki ISM bantlarında UHF radyo dalgalarını kullanır. Genellikle kablolu bağlantılara alternatif olarak, birbirine yakın taşınabilir cihazlar arasında dosya alışverişi yapmak ve müzikçalarlar ile kablosuz kulaklıkları birbirine bağlamak için kullanılır. En sık kullanılan modunda aktarım gücü 2,4 miliwatt ile sınırlı olduğu için kapsama alanı 10 metreyi geçemez.\r\n\r\nBluetooth standardı Bluetooth Special Interest Group (SIG) tarafından yönetilir. Telekomünikasyon, bilgi işlem, ağ ürünleri ve tüketici elektroniği alanlarında 35.000'den fazla şirket gruba üyedir. IEEE, Bluetooth'u IEEE 802.15.1 olarak standartlaştırmış olmasına rağmen artık bu standart üzerinde çalışmamaktadır. ",
                            PublishDate = new DateTime(2023, 2, 20, 0, 11, 50, 671, DateTimeKind.Local).AddTicks(3644),
                            RequiredMinuteToReadEntireArticle = 2,
                            TotalReadCount = 5
                        });
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AboutMe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AuthorConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutMe = "Merhaba, ben kurucu yazarım.",
                            ApplicationUserId = "dea11798-f61f-44c5-bc5f-324a314e12d1",
                            AuthorConfirmed = true,
                            AuthorName = "Anasayfa Yazarı"
                        });
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Adalet"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Bilim"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Çevre"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Dünya"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Ekonomi"
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Enerji"
                        },
                        new
                        {
                            Id = 7,
                            CategoryName = "Finans"
                        },
                        new
                        {
                            Id = 8,
                            CategoryName = "Genetik"
                        },
                        new
                        {
                            Id = 9,
                            CategoryName = "Haberleşme"
                        },
                        new
                        {
                            Id = 10,
                            CategoryName = "İnsanlar"
                        },
                        new
                        {
                            Id = 11,
                            CategoryName = "Kültür"
                        },
                        new
                        {
                            Id = 12,
                            CategoryName = "Sanat"
                        },
                        new
                        {
                            Id = 13,
                            CategoryName = "Sağlık"
                        },
                        new
                        {
                            Id = 14,
                            CategoryName = "Teknoloji"
                        });
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "dea11798-f61f-44c5-bc5f-324a314e12d1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "db22a102-c7ba-4f64-abe8-eccb408986e1",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEBMjkwxQhu62PvaTXWkTqKv6EzzHql8ZMAR8cLqKuQrStoz2qX2aHCUWhqpBCrGK/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4253bb30-abb6-44c6-8888-f955656e084e",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            FirstName = "admin",
                            LastName = "admin"
                        },
                        new
                        {
                            Id = "6ddc7555-5116-45a6-ae6f-fc2291f2d00c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5aa0531b-50a2-49f2-9b01-e79925c16356",
                            Email = "test@test.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST@TEST.COM",
                            NormalizedUserName = "TEST",
                            PasswordHash = "AQAAAAEAACcQAAAAEEbLJjPnAihzJmGUiBzX97uWI/KRA363zxAo0USRo8sdu5Kg00AqQ8QqsU/akq3mMw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6636fea3-7e72-443a-9705-5d1e9fe597a5",
                            TwoFactorEnabled = false,
                            UserName = "test",
                            FirstName = "testName",
                            LastName = "testLastName"
                        });
                });

            modelBuilder.Entity("AuthorCategory", b =>
                {
                    b.HasOne("MyBlogWebsite.Models.Concrete.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlogWebsite.Models.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("FavoryCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.Article", b =>
                {
                    b.HasOne("MyBlogWebsite.Models.Concrete.Author", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlogWebsite.Models.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.Author", b =>
                {
                    b.HasOne("MyBlogWebsite.Models.Concrete.ApplicationUser", "ApplicationUser")
                        .WithOne("Author")
                        .HasForeignKey("MyBlogWebsite.Models.Concrete.Author", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.Author", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MyBlogWebsite.Models.Concrete.ApplicationUser", b =>
                {
                    b.Navigation("Author")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

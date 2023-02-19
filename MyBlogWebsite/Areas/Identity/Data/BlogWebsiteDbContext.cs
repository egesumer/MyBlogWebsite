using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Data_Access_Folder.EntityConfigurations;
using MyBlogWebsite.Data_Access_Layer_Folder_.EntityConfigurations;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Areas.Identity.Data;

public class BlogWebsiteDbContext : IdentityDbContext<IdentityUser>
{
    public BlogWebsiteDbContext(DbContextOptions<BlogWebsiteDbContext> options)
        : base(options)
    {

    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Article> Articles { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AuthorEntityConfiguration());
        builder.ApplyConfiguration(new ArticleEntityConfiguration());
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        builder.ApplyConfiguration(new CategoryEntityConfiguration());


        string adminRoleId = Guid.NewGuid().ToString();
        string standardRoleId = Guid.NewGuid().ToString();

        IdentityRole adminRole = new IdentityRole() { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN" };
        IdentityRole standardRole = new IdentityRole() { Id = standardRoleId, Name = "standard", NormalizedName = "STANDARD" };

        builder.Entity<IdentityRole>().HasData(adminRole);
        builder.Entity<IdentityRole>().HasData(standardRole);

        string adminUserId = Guid.NewGuid().ToString();
        string standardUserId = Guid.NewGuid().ToString();

        var passwordHasher = new PasswordHasher<IdentityUser>();


        ApplicationUser adminUser = new ApplicationUser()
        {
            Id = adminUserId,
            FirstName = "admin",
            LastName = "admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            EmailConfirmed = true,
        };

        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "sifre");       // kullanıcı adı "admin" - şifren "sifre". DB'de Hashli. 
        //adminUser.Author = new Author { ApplicationUserId = adminUser.Id, AuthorName ="AdminAuthor" };

        ApplicationUser standardUser = new ApplicationUser()
        {
            Id = standardUserId,
            FirstName = "testName",
            LastName = "testLastName",
            Email = "test@test.com",
            NormalizedEmail = "TEST@TEST.COM",
            UserName = "test",
            NormalizedUserName = "TEST",
            EmailConfirmed = true,
        };
        standardUser.PasswordHash = passwordHasher.HashPassword(standardUser, "sifre");    // kullanıcı adı "test" - şifren "sifre". Db'de Hashli
        


        builder.Entity<ApplicationUser>().HasData(adminUser);
        builder.Entity<ApplicationUser>().HasData(standardUser);
      


        IdentityUserRole<string> adminUserRole = new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId,
        };

        IdentityUserRole<string> standardUserRole = new IdentityUserRole<string>
        {
            RoleId = standardRoleId,
            UserId = standardUserId,
        };


        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standardUserRole);


        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminUserId,
            Id = 1,
            ClaimType = "IsAdmin",
            ClaimValue = "true",
        });

        #region Kategori Oluşturma
        builder.Entity<Category>().HasData(new Category { 
        Id = 1, CategoryName = "Adalet"
        },
        new Category { Id = 2, CategoryName = "Bilim"
        },new Category
        {
            Id = 3, CategoryName = "Çevre"
        }, new Category {
        Id = 4, CategoryName = "Dünya"
        }, new Category
        {
            Id = 5,
            CategoryName = "Ekonomi"
        }, new Category
        {
            Id = 6, CategoryName = "Enerji"
        }, new Category
        {
            Id = 7,
            CategoryName = "Finans"
        }, new Category
        {
            Id = 8,
            CategoryName = "Genetik"
        }, new Category
        {
            Id = 9,
            CategoryName = "Haberleşme"
        }, new Category
        {
            Id = 10,
            CategoryName = "İnsanlar"
        }, new Category
        {
            Id = 11,
            CategoryName = "Kültür"
        }, new Category
        {
            Id = 12,
            CategoryName = "Sanat"
        }, new Category
        {
            Id = 13, CategoryName ="Sağlık"
        },
        new Category
        {
            Id = 14, CategoryName="Teknoloji"
        });
        #endregion

        builder.Entity<Author>().HasData(new Author
        {
            Id = 1,
            AuthorName = "Anasayfa Yazarı",
            AuthorConfirmed= true,
          //  ApplicationUser= adminUser,
            ApplicationUserId= adminUser.Id,
            AboutMe="Merhaba, ben kurucu yazarım.",
            
        });

        builder.Entity<Article>().HasData(new Article
        {
            Id= 1,
            AuthorId = 1,
            CategoryId = 4,
            PublishDate= DateTime.Now,
            RequiredMinuteToReadEntireArticle =2,
            TotalReadCount = 5,
            ArticleTitle = "Küresel Isınma - Nedenler ve Sonuçları",
            Content = "Küresel ısınma, Dünya'nın sürekli olarak artan ortalama sıcaklığıdır. Bu sıcaklık artışı, insan aktiviteleri tarafından salınan sera gazlarının atmosferdeki miktarının artmasına bağlıdır.\r\n\r\nSera gazları, güneş ışığının Dünya'ya ulaşmasına izin verirken, aynı zamanda bu ışığın tekrar atmosfer tarafından emilmesini engeller. Böylece, atmosferdeki sera gazları, Dünya'nın sıcaklığını yükseltir.\r\n\r\nİnsan aktiviteleri, sera gazı salınmasını artıran en büyük nedenlerden biridir. Endüstriyel faaliyetler, ulaşım, tarım ve enerji üretimi gibi faaliyetler, CO2 ve diğer sera gazlarının atmosfere salınmasına neden olur.\r\n\r\nKüresel ısınmanın sonuçları ciddi ve uzun vadelidir. Bu sonuçlar arasında; deniz seviyesinin yükselmesi, buzulların erimesi, iklim değişikliği, biyolojik çeşitlilikte azalma ve su kaynaklarının azalması gibi faktörler bulunur.\r\n\r\nDünya çapında, küresel ısınma konusunda acil bir müdahale gerekmektedir. İnsanlar, sera gazı salınmasını azaltmak için sürdürülebilir enerji kaynaklarına yönelmeli ve enerji verimliliğini artırmalıdır. Ayrıca, ülkeler arasında küresel ısınmaya karşı ortak bir mücadele başlatılması gerekmektedir.",
		},
        new Article
        {
			Id = 2,
			AuthorId = 1,
            CategoryId = 5,
			PublishDate = DateTime.Now,
			RequiredMinuteToReadEntireArticle = 2,
			TotalReadCount = 5,
			ArticleTitle = "İstanbul Sanayi - Türkiye ve Dünya Ekonomisi İçin Önemli Bir Merkez",
			Content = "İstanbul, Türkiye'nin en büyük ve en kalabalık şehridir ve sanayi açısından da oldukça önemlidir. İstanbul sanayi, Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlar.\r\n\r\nİstanbul'da bulunan sanayi tesisleri, çeşitli sektörlerde üretim yapmaktadır. Bunlar arasında metalürji, tekstil, gıda, elektronik, petrokimya gibi sektörler bulunmaktadır. Bu sektörler, Türkiye ekonomisi için hayati önem taşır ve İstanbul sanayi, bu sektörlerin önemli bir merkezidir.\r\n\r\nİstanbul sanayi, aynı zamanda Türkiye'nin dış ticaretini de destekler. İstanbul limanı, Türkiye'nin en büyük ve en önemli limanıdır ve bu liman, İstanbul sanayi için de önemlidir. İstanbul sanayi ürünleri, dünya çapında ihracat yapılmasını mümkün kılar.\r\n\r\nSonuç olarak, İstanbul sanayi, Türkiye ve dünya ekonomisi için önemli bir merkezdir. İstanbul sanayi, Türkiye ekonomisi için hayati önem taşır ve dünya çapında üretim ve ihracat yapılmasını mümkün kılar. İstanbul sanayi, gelecekte de Türkiye'nin ekonomik büyümesine ve gelişmesine katkı sağlamaya devam edecektir.",
		},
        new Article
        {
			Id = 3,
			AuthorId = 1,
            CategoryId = 3,
			PublishDate = DateTime.Now,
			RequiredMinuteToReadEntireArticle = 2,
			TotalReadCount = 5,
			ArticleTitle = "Geridönüşüm - Hayatımız ve Dünyamız İçin Önemli Bir Adım",
			Content = "Geridönüşüm, atık materyallerin tekrar kullanılması veya işlenerek farklı bir ürüne dönüştürülmesidir. Bu süreç, çevresel açıdan faydalıdır çünkü atıkların depolanması veya yok edilmesi yerine tekrar kullanılması sayesinde çevresel sorunları azaltır.\r\n\r\nAyrıca, geridönüşüm, ekonomik açıdan da avantajlıdır. Geridönüştürülen materyallerin üretimi, yeni materyal üretiminden daha düşük enerji ve kaynak gerektirir. Böylece, enerji tasarrufu sağlanır ve doğal kaynaklar korunur.\r\n\r\nHerkesin katkıda bulunabileceği bir konu olan geridönüşüm, evlerimizden başlayarak uygulanabilir. Atıkları sınıflandırarak, geri dönüştürülebilir materyalleri ayrı tutmak, çevresel ve ekonomik açıdan faydalıdır.\r\n\r\nSonuç olarak, geridönüşüm, hayatımız ve dünyamız için önemli bir adımdır. Herkesin katkıda bulunabileceği bu süreç, çevresel ve ekonomik açıdan faydalı olduğu kadar, gelecek nesillere daha temiz ve daha sağlıklı bir dünya bırakmak için de önemlidir. Üstelik, geridönüşüm yapmak kolaydır ve her yaşta herkes tarafından uygulanabilir. Bugünden başlayarak, atıklarımızı geridönüştürerek, dünyamızın geleceğine katkıda bulunabiliriz.",
            
		}
        ,
        new Article
        {
            Id = 4,
            AuthorId = 1,
            CategoryId = 7,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "Türkiye Ekonomisi",
            Content = "Türkiye’nin küresel dalgalanmalardan en çok etkilenen ülkelerden biri olması nedeniyle en önemli gündemini ekonomi oluşturmaktadır. 2000’li yıllarda yaşanan küresel krizlerin etkisiyle daralan Türkiye ekonomisi, takip eden yıllarda iyileşme sürecine girse de genel olarak olası dış şoklara karşı kırılgan yapısını sürdürmektedir. Türkiye ekonomisinin bu kırılgan yapısının temel nedenini aslında 24 Ocak 1980 kararlarıyla birlikte uygulamaya geçirilen yapısal uyum politikaları oluşturmaktadır. Yapısal uyum politikaları ile Türkiye ekonomisinde dışa dönük ve ihracata dayalı sanayileşme stratejileri uygulanmış böylece ithal ikameci politikalarla dış ticaret baskı altına alınmıştır.",

        }
        ,
        new Article
        {
            Id = 5,
            AuthorId = 1,
            CategoryId = 1,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "Adalet Nedir?",
            Content = "Öncelikle adalet, karşılıklı insan ilişkilerini düzenleyen toplumsal\r\ndüzenin mümkün, ama zorunlu olmayan bir niteliğidir. O, ancak tali\r\nolarak insanın bir erdemidir; çünkü insan, eğer davranışı adil olarak\r\nkabul edilen toplumsal bir düzenin normlarına uyuyorsa adildir. Peki,\r\ntoplumsal bir düzenin adil olduğunu söylemek gerçekte ne anlama gelir? O şu demektir: bu (toplumsal) düzen, insan davranışlarını herkesi\r\ntatmin edecek şekilde düzenlemiştir. Yani herkes, o düzende mutluluğu bulabilir. Adalet arzusu, insanın mutluluk için duyduğu ebedi\r\narzudur. O, insanın yalıtılmış bir şekilde, yani yalnız başına bulamayacağı, bu nedenle bir toplum içinde aradığı bir mutluluktur. Yani\r\nadalet, toplumsal mutluluktur. O, toplumsal düzen tarafından garanti\r\nedilmiş bir mutluluktur. Bu bağlamda, adaleti mutluluk olarak tanımlayan Eflatun, sadece adil insanın mutlu ve adil olmayanın da mutsuz\r\nolduğunu ileri sürer. (Ancak) adaletin mutluluk olduğu yönündeki\r\nifade, elbette ki nihai cevap değildir; o, sadece soruyu değiştirmektir.\r\nÇünkü şu halde sormamız gerekir: Mutluluk nedir?\r\n",

        }
        ,
        new Article
        {
            Id = 6,
            AuthorId = 1,
            CategoryId = 2,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "Bilimin Esası",
            Content = "Bilim, en küçük atomaltı parçacıklardan en büyük galaksi kümelerine kadar, fiziksel ve doğal dünyanın yapısını ve davranışlarını gözlem ve deney yoluyla, sistematik bir şekilde inceleyen, entelektüel ve pratik bir faaliyet olarak tanımlanabilir.Bilim, Evren'e, parçalarına ve varsa ötesine dair genel gerçekleri ve temel yasaları öğrenme yolunda çıkılan bir yolculuk; bir veri toplama, değerlendirme ve öngörü aracı olarak da düşünülebilir. Bir diğer deyişle bilim, doğal dünyada olan biteni ve bunların nasıl işlediğini öğrenmenin bir yoludur; bu bakımdan bilim, pul koleksiyonu yapmak gibi gerçekleri toplamaktan ibaret değildir; onları açıklayıp, anlamayı da hedefler",

        }
        ,
        new Article
        {
            Id = 7,
            AuthorId = 1,
            CategoryId = 6,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "Küreselleşme ve Enerji Gidişatı",
            Content = "Küreselleşmeyle birlikte son zamanlarda sanayi alanında gelişmelerin yaşanması, teknolojinin ilerlemesi nüfusun artması gibi birçok sebep enerji kaynaklarının kullanımını hızla arttırmaktadır. Sınırlı olarak bulunan fosil yakıtlarının gelecek dönemlerde yetersiz olacağı bilinmektedir. Aynı zamanda dünya ülkelerinin bu yakıtları ele geçirme isteği gün geçtikçe artmaktadır. Bunun için Enerji geçmişten günümüze her toplumun önemli sorunlarından birini oluşturmaktadır. Ayrıca enerji kaynaklarının bilinçsizce kullanılması ve mevcut kaynakların hızla tükenmesi sonucu insanlar farklı enerji kaynağı arayışına girmektedir. Hali hazırda kullanılan fosil yakıtların ömrünün azalması aynı zamanda çevreye ve insan sağlığına olumsuz etkisi ülkelerin yenilenebilir enerji kaynaklarına yönelmesine sebep olmaktadır. Güneş, jeotermal, rüzgar, biyokütle, dalga enerjisi gibi yenilenebilir enerji kaynakları son dönemlerde ülkeler tarafından tercih edilen alternatif enerji kaynaklarıdır. Bu çalışmada hem dünyanın hem de Türkiye’ nin enerji kaynaklarını tüketme payları incelenmekte ve buna bağlı olarak alternatif enerji kaynaklarının gerekliliği üzerinde durulmaktadır. Aynı zamanda Türkiye’ de yenilenebilir enerji kaynaklarının mevcut kapasiteleri ve potansiyelleri üzerine bir değerlendirme yapılmaktadır.",

        }
        ,
        new Article
        {
            Id = 8,
            AuthorId = 1,
            CategoryId = 8,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "Genetiğin Tarihi ve Gelişimi",
            Content = "Genetik ya da kalıtım bilimi, biyolojinin organizmalardaki kalıtım ve genetik varyasyonu inceleyen bir dalıdır.Türkçeye Almancadan geçen genetik sözcüğü 1831 yılında Yunanca γενετικός - genetikos (\"genitif\") sözcüğünden türetildi. Bu sözcüğün kökeni ise γένεσις - genesis (\"köken\") sözcüğüne dayanmaktadır.\r\n\r\nCanlıların özelliklerinin kalıtsal olduğunun bilinci ile tarih öncesi çağlardan beri bitki ve hayvanlar ıslah edilmiştir. Bununla birlikte, kalıtımsal aktarım mekanizmalarını anlamaya çalışan modern genetik bilimi ancak 19. yüzyılın ortalarında, Gregor Mendel’in çalışmasıyla başlamıştır. Mendel, kalıtımın fiziksel temelini bilemediyse de, bu özelliklerin ayrık (kesikli) bir tarzda aktarıldığını gözlemlemiştir; günümüzde bu kalıtım birimlerine \"gen\" adı verilmektedir.\r\n\r\nGenler DNA'da belli bölgelere karşılık gelir. DNA dört tip nükleotitten oluşan bir zincir moleküldür. Bu zincir üzerinde nükleotitlerin dizisi, organizmaların kalıt aldığı genetik bilgidir (enformasyon). Doğada DNA, iki zincirli bir yapıya sahiptir. DNA'daki her \"iplikçik\"teki nükleotitler birbirini tamamlar, yani her iplikçik, kendine eş yeni bir iplikçik oluşturmak için bir kalıp olabilme özelliğine sahiptir. Bu, genetik bilginin kopyalanması ve kalıtımı için işleyen fiziksel mekanizmadır.",

        }
        ,
        new Article
        {
            Id = 9,
            AuthorId = 1,
            CategoryId = 10,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "İnsanlığın Gelişimi",
            Content = "İnsanlık tarihi, insanlığın geçmişinin tasviridir. Arkeoloji, antropoloji, genetik, dilbilim, epigrafi, filoloji, paleografi ve diğer disiplinler ile yazının icadından bu yana, kayıtlı tarih, ikincil kaynaklar ve araştırmalar yoluyla incelenir.\r\n\r\nİnsanlık tarihi, Paleolitik Çağ'dan (Eski Taş Devri) başlayıp, ardından Neolitik Çağ'ın (Cilalı Taş Devri) takip ettiği tarih öncesine dayanıyordu. Neolitik Çağ, Yakın Doğu'nun Bereketli Hilal'inde, tarım devriminin MÖ 10.000 ila 5.000 yılları arasında başladığına tanık oldu. Bu dönemde insanlar sistematik bitki ve hayvan yetiştiriciliğine başladı.[1] Tarım ilerledikçe çoğu insan, göçebelikten yerleşik bir yaşam tarzına geçiş yaptı ve genellikle çiftçi olarak kalıcı yerleşkelerde yaşamaya başladı. Çiftçiliğin sağladığı göreceli güvenlik ve artan üretkenlik, insan toplulukların ulaşımdaki gelişmelerle birlikte giderek daha büyük birimlere genişlemesini sağladı.",

        }
        ,
        new Article
        {
            Id = 10,
            AuthorId = 1,
            CategoryId = 9,
            PublishDate = DateTime.Now,
            RequiredMinuteToReadEntireArticle = 2,
            TotalReadCount = 5,
            ArticleTitle = "Bluetooth Nedir?",
            Content = "Bluetooth, sabit veya taşınabilir cihazlar arasında kısa mesafelerde veri aktarımı yapmaya veya kişisel alan ağları (PAN) kurmaya yarayan kablosuz bağlantı standardı.2,02 GHz ile 2,48 GHz aralığındaki ISM bantlarında UHF radyo dalgalarını kullanır. Genellikle kablolu bağlantılara alternatif olarak, birbirine yakın taşınabilir cihazlar arasında dosya alışverişi yapmak ve müzikçalarlar ile kablosuz kulaklıkları birbirine bağlamak için kullanılır. En sık kullanılan modunda aktarım gücü 2,4 miliwatt ile sınırlı olduğu için kapsama alanı 10 metreyi geçemez.\r\n\r\nBluetooth standardı Bluetooth Special Interest Group (SIG) tarafından yönetilir. Telekomünikasyon, bilgi işlem, ağ ürünleri ve tüketici elektroniği alanlarında 35.000'den fazla şirket gruba üyedir. IEEE, Bluetooth'u IEEE 802.15.1 olarak standartlaştırmış olmasına rağmen artık bu standart üzerinde çalışmamaktadır. ",

        });


    }
}




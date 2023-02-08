﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Data_Access_Layer_Folder_.EntityConfigurations;
using MyBlogWebsite.Models.Concrete;

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



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AuthorEntityConfiguration());
        builder.ApplyConfiguration(new ArticleEntityConfiguration());
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());



        string adminRoleId = Guid.NewGuid().ToString();
        string standardRoleId = Guid.NewGuid().ToString();
     //   string mainpagerRoleId = Guid.NewGuid().ToString();

        IdentityRole adminRole = new IdentityRole() { Id = adminRoleId, Name = "admin", NormalizedName = "ADMIN" };
        IdentityRole standardRole = new IdentityRole() { Id = standardRoleId, Name = "standard", NormalizedName = "STANDARD" };
       // IdentityRole mainpageRole = new IdentityRole() { Id = mainpagerRoleId, Name = "mainpage", NormalizedName = "MAINPAGE" };

        builder.Entity<IdentityRole>().HasData(adminRole);
        builder.Entity<IdentityRole>().HasData(standardRole);
        //builder.Entity<IdentityRole>().HasData(mainpageRole);

        string adminUserId = Guid.NewGuid().ToString();
        string standardUserId = Guid.NewGuid().ToString();
       // string mainpageUserId = Guid.NewGuid().ToString();
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
        //standardUser.Author = new Author { ApplicationUserId = standardUser.Id, AuthorName = "standardYazar"};


        //ApplicationUser mainpageUser = new ApplicationUser()
        //{
        //    Id = mainpageUserId,
        //    FirstName = "mainpage",
        //    LastName = "mainpage",
        //    Email = "main@page.com",
        //    NormalizedEmail = "MAIN@PAGE.COM",
        //    UserName = "maintest",
        //    NormalizedUserName="MAINTEST",
        //    EmailConfirmed = true,
        //};
        //mainpageUser.PasswordHash = passwordHasher.HashPassword(mainpageUser, "sifre");


        builder.Entity<ApplicationUser>().HasData(adminUser);
        builder.Entity<ApplicationUser>().HasData(standardUser);
       // builder.Entity<ApplicationUser>().HasData(mainpageUser);


        //  builder.Entity<ApplicationUser>().HasData(standardUser);
        //builder.Entity<ApplicationUser>().HasData(author, author2);
        // builder.Entity<ApplicationUser>().HasData(author2);



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

        //IdentityUserRole<string> mainpageUserRole = new IdentityUserRole<string>
        //{
        //    RoleId = mainpagerRoleId,
        //    UserId = mainpageUserId,
        //};
       // builder.Entity<IdentityUserRole<string>>().HasData(mainpageUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standardUserRole);


        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminUserId,
            Id = 1,
            ClaimType = "IsAdmin",
            ClaimValue = "true",
        });



        builder.Entity<Author>().HasData(new Author
        {
            Id = 1,
            AuthorName = "Anasayfa Yazarı",
            AuthorConfirmed= true,
          //  ApplicationUser= adminUser,
            ApplicationUserId= adminUser.Id,
        });

        builder.Entity<Article>().HasData(new Article
        {
            Id= 1,
            AuthorId = 1,
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
			PublishDate = DateTime.Now,
			RequiredMinuteToReadEntireArticle = 2,
			TotalReadCount = 5,
			ArticleTitle = "Geridönüşüm - Hayatımız ve Dünyamız İçin Önemli Bir Adım",
			Content = "Geridönüşüm, atık materyallerin tekrar kullanılması veya işlenerek farklı bir ürüne dönüştürülmesidir. Bu süreç, çevresel açıdan faydalıdır çünkü atıkların depolanması veya yok edilmesi yerine tekrar kullanılması sayesinde çevresel sorunları azaltır.\r\n\r\nAyrıca, geridönüşüm, ekonomik açıdan da avantajlıdır. Geridönüştürülen materyallerin üretimi, yeni materyal üretiminden daha düşük enerji ve kaynak gerektirir. Böylece, enerji tasarrufu sağlanır ve doğal kaynaklar korunur.\r\n\r\nHerkesin katkıda bulunabileceği bir konu olan geridönüşüm, evlerimizden başlayarak uygulanabilir. Atıkları sınıflandırarak, geri dönüştürülebilir materyalleri ayrı tutmak, çevresel ve ekonomik açıdan faydalıdır.\r\n\r\nSonuç olarak, geridönüşüm, hayatımız ve dünyamız için önemli bir adımdır. Herkesin katkıda bulunabileceği bu süreç, çevresel ve ekonomik açıdan faydalı olduğu kadar, gelecek nesillere daha temiz ve daha sağlıklı bir dünya bırakmak için de önemlidir. Üstelik, geridönüşüm yapmak kolaydır ve her yaşta herkes tarafından uygulanabilir. Bugünden başlayarak, atıklarımızı geridönüştürerek, dünyamızın geleceğine katkıda bulunabiliriz.",

		});


    }
}




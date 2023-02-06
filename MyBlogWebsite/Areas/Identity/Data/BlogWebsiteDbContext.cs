using Microsoft.AspNetCore.Identity;
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
        //standardUser.Author = new Author { ApplicationUserId = standardUser.Id, AuthorName = "standardYazar"};





        builder.Entity<ApplicationUser>().HasData(adminUser);
        builder.Entity<ApplicationUser>().HasData(standardUser);
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

        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standardUserRole);


        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminUserId,
            Id = 1,
            ClaimType = "IsAdmin",
            ClaimValue = "true",
        });

    }
}




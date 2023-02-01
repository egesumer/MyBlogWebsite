using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyBlogWebsite.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());


        
        string adminRoleId = Guid.NewGuid().ToString();
        string standardRoleId = Guid.NewGuid().ToString();
        
        
        IdentityRole adminRole = new IdentityRole(){ Id= adminRoleId, Name = "admin", NormalizedName ="ADMIN" };
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
            NormalizedUserName ="ADMIN",
            EmailConfirmed= true,
        };
           adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "sifre");       // kullanıcı adı "admin" - şifren "sifre". DB'de Hashli. 


        ApplicationUser standardUser = new ApplicationUser()
        {
            Id = standardUserId,
            FirstName = "testName",
            LastName = "testLastName",
            Email = "test@test.com",
            NormalizedEmail = "TEST@TEST.COM",
            UserName ="test",
            NormalizedUserName ="TEST",
            EmailConfirmed= true,
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
            UserId= standardUserId,
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

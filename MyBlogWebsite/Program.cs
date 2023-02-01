using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) //test'e kadar false yapýlabilir.
	.AddRoles<IdentityRole>()								// roller etkinleþtirilir.
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.Configure<IdentityOptions>(options => {
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireDigit = false;
	options.Password.RequiredLength = 3;

});


//	kullanýcý- ege@ege.com - sifre ege123


// Add services to the container.
builder.Services.AddControllersWithViews();




//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("IsAdmin", policy => policy.RequireClaim("IsAdmin", "true"));  //claim veya Rol üzerinden oluþturduðumuz þartlardan hangisi saðlanýrsa authentice olmasýný belirleme.
//                                                                                     // options.AddPolicy("AdminRequired", policy => policy.RequireClaim("Admin"));

//    //BURASI ADMIN TARAFINDAN GÖRÜLMESÝ ÝSTENEN SAYFALAR ÝÇÝN GEREKLÝ OLAN KISIM.

//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

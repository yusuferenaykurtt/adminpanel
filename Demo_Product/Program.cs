using Demo_Product.BusinessLayer.Concrete;
using Demo_Product.DataAccessLayer.Abstracts;
using Demo_Product.DataAccessLayer.Concrete;
using Demo_Product.DataAccessLayer.EntityFramework;
using Demo_Product.EntityLayer.Concrete;
using Demo_Product.EntityLayer.Concrete.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using NUnit.Util;


var builder = WebApplication.CreateBuilder(args);


var conn = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(conn))
    throw new InvalidOperationException("Missing 'ConnectionStrings:DefaultConnection' in appsettings(.Development).json");


builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(conn));

builder.Services
    .AddIdentity<AppUser, AppRole>(o =>
    {
        o.User.RequireUniqueEmail = true;
        o.Password.RequiredLength = 6;
        o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.SignIn.RequireConfirmedAccount = false;
        o.SignIn.RequireConfirmedEmail = false;
        o.SignIn.RequireConfirmedPhoneNumber = false;
    })
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.AccessDeniedPath = "/Login/AccessDenied";
});



builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ProductManager>();

builder.Services.AddScoped<IJobDal, EfJobDal>();
builder.Services.AddScoped<JobManager>();

builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<CustomerManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<Demo_Product.BusinessLayer.Concrete.CategoryManager>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<Context>();
    Console.WriteLine("DB => " + ctx.Database.GetDbConnection().ConnectionString);
}

app.Run();

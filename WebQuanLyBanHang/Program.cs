using Microsoft.EntityFrameworkCore;
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.DependencyInjection;
using WebQuanLyBanHang.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

/// Database SQL ///
builder.Services.AddDbContext<QuanLyBanHangDbContent>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLBHDatabase"));
});
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<QuanLyBanHangDbContent>();
var logger = builder.Services.BuildServiceProvider().GetService<ILogger<QuanLyBanHangDbContent>>();
builder.Services.AddSingleton(typeof(ILogger), logger);

/// Dependency Injection
DependencyInjections.Configuration(builder.Services);

/// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapProfile).Assembly);

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = opt =>
    {
        opt.HttpContext.Response.Redirect("/dang-nhap");
        return Task.FromResult(0);
    };
});

///
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
app.UseDeveloperExceptionPage();
app.UseDatabaseErrorPage();

app.UseHttpsRedirection();

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using GearTalk.Web.Data;
using GearTalk.Web.Models.ViewModel;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CarReviewDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CarReviewDbConnectionString")));

builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GearTalksAuthDbConnectionString")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
});




builder.Services.AddScoped<ICarCategory, CarCategoryRepository>();
builder.Services.AddScoped<ICarReview, CarReviewRepository>();
builder.Services.AddScoped<IImageRepository, CloudinaryImageRepository>();  
builder.Services.AddScoped<ICarReviewLikeRepository, CarReviewLikeRepository>();
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<ICarReviewCommentRepository , CarReviewCommentRepository>();



var app = builder.Build();

//resten er middleware som håndtrerer http request.
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//auto‑migrate
using (var scope = app.Services.CreateScope())
{
    var db1 = scope.ServiceProvider.GetRequiredService<CarReviewDbContext>();
    db1.Database.Migrate();

    var db2 = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    db2.Database.Migrate();
}

app.Run();


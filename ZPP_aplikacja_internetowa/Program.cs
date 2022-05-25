using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
<<<<<<< Updated upstream
using ZPP_aplikacja_internetowa.Mapper;
=======
>>>>>>> Stashed changes
using ZPP_aplikacja_internetowa.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

<<<<<<< Updated upstream

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
=======
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
>>>>>>> Stashed changes
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IAuthentication), typeof(Authentication));
builder.Services.AddTransient<SignInManager<IdentityUser>>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "ZPP_aplikacja_internetowa", Version = "v2" });
});
builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "ZPP_aplikacja_internetowa");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
app.MapRazorPages();

app.Run();

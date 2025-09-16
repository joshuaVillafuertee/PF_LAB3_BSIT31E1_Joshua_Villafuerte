using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PF_LAB3_BSIT31E1_Joshua_Villafuerte.Data;

var builder = WebApplication.CreateBuilder(args);

//  ApplicationDbContext for Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  GreedDbContext for your custom "Cards" tables
builder.Services.AddDbContext<GreedDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GreedConnection")));
//  better to use a separate connection string if possible

//  Add Identity with custom options
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Required for Identity Razor pages

var app = builder.Build();

//  Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // must be before UseAuthorization
app.UseAuthorization();

//  Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Needed for Identity

app.Run();

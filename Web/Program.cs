using LeaveMgmt.Db.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("ConnectionString 'DefaultConnection' is not found.");
builder.Services.AddDbContext<LeaveMgmtDbContext>(opt => { opt.UseSqlServer(connectionString); });

// Capture Database related exception for DeveloperExceptionPage
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Default Identity
builder.Services.AddDefaultIdentity<IdentityUser>(opt => { opt.SignIn.RequireConfirmedAccount = true; })
    .AddEntityFrameworkStores<LeaveMgmtDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

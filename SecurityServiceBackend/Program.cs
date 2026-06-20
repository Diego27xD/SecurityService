using Microsoft.EntityFrameworkCore;
using SecurityServiceBackend.Data;
using SecurityServiceBackend.Connections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BiosecurityContext>(options =>
	options.UseNpgsql(
		builder.Configuration.GetConnectionString("PostgreSqlConnection")
	));

// Add services to the container.
builder.Services.AddSingleton<SQLServerConnectionFactory>();
builder.Services.AddSingleton<SQLPostgresConnectionFactory>();
builder.Services.AddSingleton<IngresoRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
	pattern: "{controller=Login}/{action=Login}/{id?}") //pattern: "{controller=Home}/{action=Index}/{id?}");
	.WithStaticAssets();


app.Run();

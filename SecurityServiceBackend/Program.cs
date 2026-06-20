using Microsoft.EntityFrameworkCore;
using SecurityServiceBackend.Connections;
using SecurityServiceBackend.Data;
using SecurityServiceBackend.Middlewares;
using SecurityServiceBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<SessionAuthFilter>();
});

builder.Services.AddDbContext<BiosecurityContext>(options =>
	options.UseNpgsql(
		builder.Configuration.GetConnectionString("PostgreSqlConnection")
	));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbSQLServer")
    ));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddSingleton<SQLServerConnectionFactory>();
builder.Services.AddSingleton<SQLPostgresConnectionFactory>();
builder.Services.AddSingleton<IngresoRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<SessionAuthFilter>();

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
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
	pattern: "{controller=Login}/{action=Login}/{id?}") //pattern: "{controller=Home}/{action=Index}/{id?}");
	.WithStaticAssets();


app.Run();

using Microsoft.EntityFrameworkCore;
using SmartCitySecurity.Data.Contexts;
using SmartCitySecurity.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

#region Inicializando o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
        opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
 );
#endregion

#region Registro IService Collection
builder.Services.AddScoped<IRecursoPolicialRepository, IRecursoPolicialRepository>();

#endregion


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

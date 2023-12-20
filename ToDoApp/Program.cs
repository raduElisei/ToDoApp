using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Data;
namespace ToDoApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseContext") ?? throw new InvalidOperationException("Connection string 'DatabaseContext' not found.")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Map DateTime with Kind=UTC to postgreSQL type "timestamp without timezone"
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

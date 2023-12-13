using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebAppMerck.DataAccess;
using WebAppMerck.Models;
using WebAppMerck.Servicios;
using WebAppMerck.Servicios.Interfaces;

namespace WebAppMerck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var bingMapsConfig = builder.Configuration.GetSection("BingMapsCredentials");
            var bingMapsKey = bingMapsConfig["ApiKey"];

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("name=DefaultConnection");
            });

            
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ClinicasServicio>();
            builder.Services.AddScoped<CalcularFertilidad>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

            var app = builder.Build();

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
}
using Microsoft.EntityFrameworkCore;
using SendGrid;
using System.Configuration;
using WebAppMerck.DataAccess;
using WebAppMerck.Models.Key;
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

            builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGridSettings"));
            builder.Services.AddTransient<ISendGridClient>(_ => new SendGridClient(builder.Configuration["SendGridSettings:ApiKey"]));

            builder.Services.Configure<GoogleAnalyticsOptions>(builder.Configuration.GetSection("GoogleAnalytics"));

            builder.Services.AddDbContext<BdAppMerckContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BdAppMerckContext")));

            builder.Services.AddScoped<ClinicasServicio>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var filePath = config.GetValue<string>("FileUrl:GithubUrl");
                return new ClinicasServicio(filePath);
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();



            builder.Services.AddHttpClient();
            builder.Services.AddScoped<ClinicasServicio>();
            builder.Services.AddScoped<CalcularFertilidad>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();

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
                pattern: "{controller=Home}/{action=Inicio}/{id?}");

            app.Run();
        }
    }
}
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using WebAppMerck.AccesoDatos.DataAccess;
using WebAppMerck.Modelos.Models.Entities;
using WebAppMerck.Modelos.Models.Key;
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

            builder.Services.AddIdentity<Usuario, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped<ClinicasServicio>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var filePath = config.GetValue<string>("FileUrl:GithubUrl");
                return new ClinicasServicio(filePath);
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();



            builder.Services.AddHttpClient();
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            IWebHostEnvironment env = app.Environment;
            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/Windows");

            app.Run();
        }
    }
}
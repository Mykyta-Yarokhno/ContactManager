using ContactManager.Apllication;
using ContactManager.Domain;
using ContactManager.Infrastructure;
using ContactManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            builder.Services.AddScoped<ContactService>();

            // Add services to the container.
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

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contact}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

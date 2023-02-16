using LaptopVendorEFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace LaptopVendorEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LaptopDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopDB")));

            LaptopDBContext context = new LaptopDBContext();

            if (context.Laptops.Count() == 0 && context.Brands.Count() == 0)
            {
                PopulateDatabase.Populate();
            }

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
using ClickCart.Data;
using ClickCart.Data.Models;
using ClickCart.Data.Repositories;
using ClickCart.Service.OrderProducts;
using ClickCart.Service.Orders;
using ClickCart.Service.ProductCategories;
using ClickCart.Service.Products;
using ClickCart.Web.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClickCart.Web
{
    public class Program
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {


            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ClickCartDbContext>(options =>
                options.UseSqlServer(connectionString));

            //Add Custom Services
            builder.Services.AddTransient<ProductRepository, ProductRepository>();
            builder.Services.AddTransient<ProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddTransient<OrderRepository, OrderRepository>();
            builder.Services.AddTransient<OrderProductRepository, OrderProductRepository>();

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IOrderProductService, OrderProductService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                 .AddDefaultIdentity<ClickCartUser>(options =>
                 {
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequiredLength = 5;
                 })
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<ClickCartDbContext>();

            builder.Services.AddRazorPages();
            builder.Services.AddHttpContextAccessor();
        }

        public static void ConfigureAndRunApplication(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.SeedRoles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.Run();
        }

        public static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            ConfigureAndRunApplication(builder);
        }
    }
}

    





using Microsoft.EntityFrameworkCore;
using University.Data;
using Microsoft.Extensions.DependencyInjection;

namespace University
{

    //Command- Update-Database
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<UniversityContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityContext")));


            //add database exeption filter for development enviroment
            //This will show detailed database errors durning development
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Create DB if it doesn't exist and seed initial data
            CreateDbIfNotExists(app);

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
                pattern: "{controller=Home}/{action=index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        //Luuakse andmebaas, kui see veel ei eksisteeri
        //ja sisestab sinna algandmed
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<UniversityContext>();
                    DbInitializer.Initializer(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured creating the DB.");
                }
            }
        }
    }

}
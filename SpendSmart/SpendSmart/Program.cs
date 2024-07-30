using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a builder for the web application using the command-line arguments.
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the dependency injection container.
            // In this case, adding support for controllers with views (MVC pattern).
            builder.Services.AddControllersWithViews();

            // Ensure that you have the following namespaces included:
            // using Microsoft.EntityFrameworkCore;
            // using SpendSmart.Models;
            builder.Services.AddDbContext<SpendSmartDbContext>(options =>
                // Configure the DbContext to use an in-memory database for testing or development purposes.
                // Replace "SpendSmartDB" with your preferred database name.
                options.UseInMemoryDatabase("SpendSmartDB")
            );

            // Build the web application using the configured services.
            var app = builder.Build();

            // Configure the HTTP request pipeline for the application.

            // Check if the environment is not development.
            if (!app.Environment.IsDevelopment())
            {
                // Use a custom exception handler page for production environments.
                app.UseExceptionHandler("/Home/Error");

                // Enable HTTP Strict Transport Security (HSTS) with a default value of 30 days.
                // HSTS enforces secure (HTTPS) connections to the server.
                app.UseHsts();
            }

            // Redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Serve static files (e.g., CSS, JavaScript, images) from the wwwroot folder.
            app.UseStaticFiles();

            // Set up routing to handle incoming requests.
            app.UseRouting();

            // Enable authorization middleware to enforce authorization policies.
            app.UseAuthorization();

            // Map the default controller route with optional parameters.
            // The default route pattern is "{controller=Home}/{action=Index}/{id?}".
            // This means that if no specific route is provided, it will default to the Home controller and Index action.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Start the web application and listen for incoming HTTP requests.
            app.Run();
        }
    }
}

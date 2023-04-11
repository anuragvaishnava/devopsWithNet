using Microsoft.AspNetCore.Builder;
using Shopping.Client.Controllers;

namespace Shopping.Client
{
    public class Startup
    {
        public IConfiguration _configuration
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddHttpClient("ShoppingAPIClient", client => {
                client.BaseAddress = new Uri(_configuration["ShoppingAPIUrl"]);
            });

            services.AddRazorPages();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}

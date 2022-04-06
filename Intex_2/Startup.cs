using Intex_2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<CrashDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:CrashDBConnection"]);
            });

            services.AddScoped<ICrashRepository, EFCrashRepository>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            services.AddDbContext<AppIdentityDBContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:IdentityDBConnection"]);
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDBContext>();
            services.Configure<IdentityOptions>(options =>
            {
                //Password requirements
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                //
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Page number and severity
                endpoints.MapControllerRoute(
                    name: "severitypage",
                    pattern: "/ViewCrashes/{crashSeverity}/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "ViewCrashes" });

                // Page number only
                endpoints.MapControllerRoute(
                    name: "page",
                    pattern: "/ViewCrashes/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "ViewCrashes" });

                // Severity only
                endpoints.MapControllerRoute(
                    name: "severity",
                    pattern: "/ViewCrashes/{crashSeverity}",
                    defaults: new { Controller = "Home", action = "ViewCrashes", pageNum = 1 });

                // Crash details page
                endpoints.MapControllerRoute(
                    name: "crashdetails",
                    pattern: "/CrashDetails/{crashId}/{returnPage}",
                    defaults: new { Controller = "Home", action = "CrashDetails" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}

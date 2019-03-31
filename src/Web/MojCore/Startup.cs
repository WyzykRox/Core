using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Models.Entities;
using Infrastructure.DAO.Data;
using Infrastructure.ExternalServices;
using System;
using Infrastructure.DAO.Initializers;
using Core.Repositories.Abstract;
using Core.Repositories;

using Core.Services.Abstract;
using Core.Services;

namespace Web.MojCore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Use SQL Database if in Azure, otherwise, use SQLite
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(
                            Configuration.GetConnectionString(
                                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production"
                                    ? "ProductionDbConnectionString"
                                    : "DevelopmentDbConnectionString"
                                )));
           

            // Add application services.    
            services.AddSingleton<IMessage, MessageService>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IProfileImageRepository, ProfileImageRepository>();
            services.AddScoped<IProfileImageService, ProfileImageService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsService, NewsService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
           IHostingEnvironment env,
           ApplicationDbContext context,
           RoleManager<Role> roleManager,
           UserManager<User> userManager
         )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            RoleInitializer.Initialize(roleManager, context).Wait();// seed here
            UserInitializer.Initialize(userManager, roleManager, context).Wait();// seed here
        }
    }
}

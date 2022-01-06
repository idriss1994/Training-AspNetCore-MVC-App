using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using Training_App.Models;

namespace Training_App
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

            //DbContext configuration
            services.AddDbContextPool<AppDbContext>(options =>
            {
                //SqlServer Db provider config
                options.UseSqlServer(Configuration.GetConnectionString("MyCon"));
            });
            // configure identity service:
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {

                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;

            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders(); //To generate Reset Password Token 


            //configure external auhentication
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "78731528798-s1surd83hg9pt4rgshfe3sd42tbfh8i8.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                })
                .AddFacebook(options =>
                {
                    options.AppId = "1311299282680114";
                    options.AppSecret = "09969c4e56038ebbdf94eb0090731eff";
                });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

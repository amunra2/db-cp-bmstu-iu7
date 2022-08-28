using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using ServerING.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using ServerING.Services;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Repository;
using System.IO;
using ServerING.Logger;

namespace ServerING {
    public class Startup {

        /*private IConfigurationRoot _configuration;

        public Startup(IWebHostEnvironment hostEnv) {
            _configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }*/

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
            Configuration["DatabaseConnection"] = configuration.GetConnectionString("nonAuthUserConnection"); // DefaultConnection
        }


        public void ConfigureServices(IServiceCollection services) {

            // Change connection String to DB
            services.AddDbContext<AppDBContent>(options =>
                options.UseNpgsql(Configuration["DatabaseConnection"]),
                ServiceLifetime.Transient);

            services.AddSingleton<IConfiguration>(Configuration);
            //

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            // Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IServerService, ServerService>();
            services.AddTransient<IPlatformService, PlatformService>();
            services.AddTransient<IWebHostingService, WebHostingService>();
            services.AddTransient<IPlayerService, PlayerService>();


            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IServerRepository, ServerRepository>();
            services.AddTransient<IWebHostingRepository, WebHostingRepository>();
            services.AddTransient<IPlatformRepository, PlatformRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            services.AddControllersWithViews();

            /*// Connect to DB -- Old variant
            if (_configuration["Database"] == "Postgres") {
                services.AddDbContext<AppDBContent>(options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));
            }
            else if (_configuration["Database"] == "MSSqlServer") {
                services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_configuration.GetConnectionString("MSSqlServerConnection")));
            }
            else {
                Console.WriteLine("WTF?");
                services.AddDbContext<AppDBContent>(options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));
            }*/

            /* // Connect to DB -- New variant
            var provider = _configuration["Database"];

            services.AddDbContext<AppDBContent>(
                options => _ = provider switch {
                    "Postgres" => options.UseNpgsql(
                        _configuration.GetConnectionString("DefaultConnection")
                        ),

                    "MSSqlServer" => options.UseSqlServer(
                        _configuration.GetConnectionString("MSSqlServerConnection")
                        ),

                    _ => throw new Exception($"Unsupported provider: {provider}")
                }
            ); */
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            // Logger
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs"));


            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

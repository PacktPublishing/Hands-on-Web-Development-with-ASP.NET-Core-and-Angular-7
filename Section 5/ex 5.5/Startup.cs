using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DVDMovie.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DVDMovie
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
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration
                    ["Data:Movies:ConnectionString"]));
            services.AddMvc().AddJsonOptions(opts =>{
                		opts.SerializerSettings.ReferenceLoopHandling
                   		 	= ReferenceLoopHandling.Serialize;
                        opts.SerializerSettings.NullValueHandling 
                            = NullValueHandling.Ignore;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Added for handling sessions
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString =
                    Configuration["Data:Movies:ConnectionString"];
                options.SchemaName = "dbo";
                options.TableName = "SessionData";
            });
            // Added for handling sessions
            services.AddSession(options =>
            {
                options.Cookie.Name = "DVDMovie.Session";
                options.IdleTimeout = System.TimeSpan.FromHours(48);
                options.Cookie.HttpOnly = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                DataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSession();       // Added for handling sessions
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            SeedData.SeedDatabase(context);
        }
    }
}

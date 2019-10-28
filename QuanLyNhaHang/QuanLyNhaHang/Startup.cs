using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QuanLyNhaHang {
    public class Startup {

        public Startup (IConfiguration configuration) {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            // services.Configure<RazorViewEngineOptions> (options => {
            //     options.AreaViewLocationFormats.Clear ();
            //     options.AreaViewLocationFormats.Add ("/Areas/{2}/Views/{1}/{0}.cshtml");

            // });
            //Server=(localdb)\\mssqllocaldb;Database=QLNH;Trusted_Connection=True;MultipleActiveResultSets=true
            services.AddDistributedMemoryCache ();
            services.AddSession (options =>
                options.IdleTimeout = TimeSpan.FromMinutes (60)
            );
            services.AddControllersWithViews ();
            services.AddDbContext<QLNHContext> (option => option.UseSqlite (Configuration.GetConnectionString ("QLNHContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }
            app.UseStaticFiles ();

            app.UseSession ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");

            });

        }
    }
}
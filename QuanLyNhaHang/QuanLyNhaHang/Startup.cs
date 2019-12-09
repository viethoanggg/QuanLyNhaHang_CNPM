using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLyNhaHang.Services;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Server=(localdb)\\mssqllocaldb;Database=QLNH;Trusted_Connection=True;MultipleActiveResultSets=true
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
               options.IdleTimeout = TimeSpan.FromMinutes(60)
            );

            services.AddScoped<IThucDonRepository, ThucDonRepository>();
            services.AddScoped<IBanAnRepository, BanAnRepository>();
            services.AddScoped<IHoaDonRepository, HoaDonRepository>();
            services.AddScoped<ILoaiMonAnRepository, LoaiMonAnRepository>();
            services.AddScoped<IKhachHangRepository, KhachHangRepository>();
            services.AddScoped<IPhieuDatBanRepository, PhieuDatBanRepository>();
            services.AddScoped<INguoiDungRepository, NguoiDungRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IThucDonServices, ThucDonServices>();
            services.AddScoped<IBanAnServices, BanAnServices>();
            services.AddScoped<IHoaDonServices, HoaDonServices>();
            services.AddScoped<ILoaiMonAnServices, LoaiMonAnServices>();
            services.AddScoped<IKhachHangServices, KhachHangServices>();
            services.AddScoped<IPhieuDatBanServices, PhieuDatBanServices>();
            services.AddScoped<INguoiDungServices, NguoiDungServices>();

            services.AddScoped<IThucDonIndexVMServices, ThucDonIndexVMServices>();
            services.AddScoped<ILoaiMonAnIndexVMServices, LoaiMonAnIndexVMServices>();
            services.AddScoped<IHoaDonIndexVMServices, HoaDonIndexVMServices>();
            services.AddScoped<IPhieuDatBanIndexVMServices, PhieuDatBanIndexVMServices>();
            services.AddScoped<IKhachHangIndexVMServices, KhachHangIndexVMServices>();
            services.AddScoped<INguoiDungIndexVMServices, NguoiDungIndexVMServices>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllersWithViews();
            services.AddDbContext<QLNHContext>(option => option.UseSqlite(Configuration.GetConnectionString("QLNHContext")));
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
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");

            });

        }
    }
}
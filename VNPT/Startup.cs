﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using VNPT.Data.Models;
using VNPT.Data.Repositories;

namespace VNPT
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
            // Add framework services.
            services
                .AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddDbContext<VNPTContext>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<IMembershipPropertyRepository, MembershipPropertyRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IInvoicePropertyRepository, InvoicePropertyRepository>();
            services.AddTransient<IConfigRepository, ConfigRepository>();
            services.AddTransient<IPhieuYeuCauRepository, PhieuYeuCauRepository>();
            services.AddTransient<IPhieuYeuCau_ThuocTinhRepository, PhieuYeuCau_ThuocTinhRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductConfigRepository, ProductConfigRepository>();
            // Add Kendo UI services to the services container
            services.AddKendo();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Blog",
                    pattern: "{MetaTitle}-{ID}.html",
                    defaults: new { controller = "Home", action = "Blog" });

                endpoints.MapControllerRoute(
                    name: "Blogs",
                    pattern: "{Note}-{ID}",
                    defaults: new { controller = "Home", action = "Blogs" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

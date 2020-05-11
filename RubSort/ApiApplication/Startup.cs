﻿using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubSort.DataStorageSystem;
using RubSort.IdentitySystem;
using RubSort.MapSystem;
using RubSort.RecyclingPointsSystem;

namespace RubSort.ApiApplication
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
            // todo: заменить на services.AddControllers();
            // todo: когда разделим веб-приложение и API
            services.AddControllersWithViews();
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<HttpClient>();
            
            AddDataStorageSystem(services);
            // AddIdentitySystem(services);
            AddRecyclingPointsSystem(services);
            AddMapSystem(services);
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

            // app.UseHttpsRedirection();

            app.UseRouting();
            // app.UseAuthentication();
            app.UseEndpoints(routes =>
            {
                routes.MapDefaultControllerRoute();
            });
        }

        private void AddIdentitySystem(IServiceCollection services)
        {
            services.AddScoped<AuthenticationManager>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.LoginPath = new PathString("/Authentication/Login");
                    });
        }

        private void AddMapSystem(IServiceCollection services)
        {
            services.AddScoped<MapGetter>();
            services.AddScoped<IMapApiClient, YandexMapApiClient>();
        }

        private void AddRecyclingPointsSystem(IServiceCollection services)
        {
            services.AddScoped<RecyclingPointProvider>();
        }

        private void AddDataStorageSystem(IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityRepository<>), typeof(SqlEntityRepository<>));
            services.AddDbContext<DbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("Default");
                options.UseNpgsql(connectionString);
            });
        }
    }
}
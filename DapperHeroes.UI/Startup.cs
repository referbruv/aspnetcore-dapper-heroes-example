using DapperHeroes.Contracts;
using DapperHeroes.Contracts.Repositories;
using DapperHeroes.Core.Dapper;
using DapperHeroes.Core.Dapper.Repositories;
using DapperHeroes.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DapperHeroesApp
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
            services.AddDbContext<HeroesContext>(options =>
            {
                options.UseSqlite("Data Source=app.db;");
            });

            services.AddScoped<IHeroesRepository, HeroesRepository>();

            //services.AddScoped<IDapperr, Dapperr>();
            //services.AddScoped<IHeroesRepository, DapperHeroesRepository>();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<HeroesContext>();

            //    context.Database.EnsureCreated();

            //    for (int i = 10000; i <= 99999; i++)
            //    {
            //        context.Heroes.Add(new DapperHeroes.Contracts.Entities.Hero
            //        {
            //            Name = $"SuperHero{i}",
            //            Category = (DapperHeroes.Contracts.Entities.Category)(i % 4),
            //            HasCape = i % 2 == 0,
            //            IsAlive = i % 2 != 0,
            //            Powers = String.Join(',', (new string[] { "Fly", "Eat", "Sleep", "Manga" })),
            //            Created = DateTime.UtcNow
            //        });
            //    }

            //    context.SaveChanges();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Heroes API");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

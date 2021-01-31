using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Repositories;
using Microsoft.OpenApi.Models;

namespace Catalog.API
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
            services.AddControllers();

            services.Configure<CatalogDatabaseSettings>(Configuration.GetSection("CatalogConnection"));

            // https://hassantariqblog.wordpress.com/2017/02/20/asp-net-core-step-by-step-guide-to-access-appsettings-json-in-web-project-and-class-library/
            services.AddSingleton<ICatalogDatabaseSettings>(sp => sp.GetRequiredService<IOptions<CatalogDatabaseSettings>>().Value);


            services.AddDbContextPool<CatalogDbContext>(option =>
            option.UseSqlServer(Configuration["ConnectionStrings:CatalogConnection"]));

            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog Microservice", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog Microservice v1");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

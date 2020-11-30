using AutoMapper;
using EventBusRabbitMQ;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ordering.API.Extentions;
using Ordering.API.RabbitMQ;
using Ordering.Application.Handlers;
using Ordering.Core.Repositories;
using Ordering.Core.Repositories.Base;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repository;
using Ordering.Infrastructure.Repository.Base;
using RabbitMQ.Client;
using System.Reflection;

namespace Ordering.API
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
            services.AddDbContext<OrderContext>(c =>
                   c.UseSqlServer(Configuration.GetConnectionString("OrderConnection")), ServiceLifetime.Singleton);

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));

            // It should add that assembly whereever we have Handlers otherwise it won't be able to navigate to Handlers.
            services.AddMediatR(typeof(CheckoutOrderHandler).GetTypeInfo().Assembly);
            

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            /*services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository))*/;

            #region Swagger Dependencies

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order API", Version = "v1" });
            });

            #endregion


            #region RabbitMQ bus
            services.AddSingleton<IRabbitMQConnection>(sp =>
               {
                   var factory = new ConnectionFactory()
                   {
                       HostName = Configuration["EventBus:HostName"],
                       UserName = Configuration["EventBus:UserName"],
                       Password = Configuration["EventBus:Password"]
                   };
                   return new RabbitMQConnection(factory);
               });

            services.AddSingleton<EventBusRabbitMQConsumer>(); 
            #endregion

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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseRabbitMQListner();
        }
    }
}

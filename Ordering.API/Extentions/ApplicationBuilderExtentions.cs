using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ordering.API.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Extentions
{
    public static class ApplicationBuilderExtentions
    {
        public static EventBusRabbitMQConsumer Listner { get; set; }
        public static IApplicationBuilder UseRabbitMQListner(this IApplicationBuilder applicationBuilder)
        {
           Listner = applicationBuilder.ApplicationServices.GetService<EventBusRabbitMQConsumer>();

           var life = applicationBuilder.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopped.Register(OnStopped);



            return applicationBuilder;
        }

        private static void OnStopped()
        {
            Listner.Disconnect();
        }

        private static void OnStarted()
        {
            Listner.Consume();
        }
    }
}

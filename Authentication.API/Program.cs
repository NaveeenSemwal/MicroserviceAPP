using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.API
{
    public class Program
    {
        // https://www.youtube.com/watch?v=7kVmb747vfM

        // https://medium.com/aspnetrun/securing-microservices-with-identityserver4-with-oauth2-and-openid-connect-fronted-by-ocelot-api-49ea44a0cf9e

        // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/secure-net-microservices-web-applications/

        // https://squarewidget.com/microservices-with-identityserver4-and-ocelot-fronting-a-net-core-api/


        // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot

        // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

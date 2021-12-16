using Gruppo3.Clienti.Core.Consumers;
using Gruppo3.Clienti.Domain.Repositories;
using Gruppo3.Clienti.Infrastructure.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Gruppo3.Clienti.Core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateOrderConsumer>();
                x.AddConsumer<UpdateOrderConsumer>();
                x.AddConsumer<DeleteOrderConsumer>();

                //RabbitMQ
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(
                        Environment.GetEnvironmentVariable("HOST_RABBIT"),
                        Environment.GetEnvironmentVariable("VHOST_RABBIT"),
                        hst => {
                            hst.Username(Environment.GetEnvironmentVariable("USERNAME_RABBIT"));
                            hst.Password(Environment.GetEnvironmentVariable("PASSWORD_RABBIT"));
                        });
                    //create
                    cfg.ReceiveEndpoint("Gruppo3-ClientCreateOrderEvent", e =>
                    {
                        e.ConfigureConsumer<CreateOrderConsumer>(context);
                    });

                    //update
                    cfg.ReceiveEndpoint("Gruppo3-ClientUpdateOrderEvent", e =>
                    {
                        e.ConfigureConsumer<UpdateOrderConsumer>(context);
                    });

                    //delete
                    cfg.ReceiveEndpoint("Gruppo3-ClientDeleteOrderEvent", e =>
                    {
                        e.ConfigureConsumer<DeleteOrderConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService(true);

            //interface
            services.AddSingleton<IOrderRepository, OrderRepository>();

            RepoDb.SqlServerBootstrap.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}

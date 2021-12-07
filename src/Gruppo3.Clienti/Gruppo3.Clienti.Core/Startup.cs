using Gruppo3.Clienti.Core.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                //aggiungere altre 2 classi di consumer
                x.AddConsumer<CreateOrderConsumer>();

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });

                //Usiamo RabbitMQ(?)
                /*x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(
                        "ip", 
                        "/", 
                        hst => {
                            hst.Username("user");
                            hst.Password("paswd");
                        });
                    cfg.ConfigureEndpoints(context);

                    cfg.ReceiveEndpoint("queue", e =>
                    {
                        //aggiungere altre 2 classi di consumer
                        x.AddConsumer<CreateClientConsumer>();
                    });
                });*/
            });
            services.AddMassTransitHostedService(true);
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

using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Application.Services;
using Gruppo3.Clienti.Domain.Repositories;
using Gruppo3.Clienti.Infrastructure.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Gruppo3.Clienti.WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gruppo3.Clienti.WebAPI", Version = "v1" });
            });

            //set rabbit
            services.AddMassTransit(x =>
            {
                //Usiamo RabbitMQ
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(
                        Environment.GetEnvironmentVariable("HOST_RABBIT"),
                        Environment.GetEnvironmentVariable("VHOST_RABBIT"),
                        hst => {
                            hst.Username(Environment.GetEnvironmentVariable("USERNAME_RABBIT"));
                            hst.Password(Environment.GetEnvironmentVariable("PASSWORD_RABBIT"));
                        });
                });
            });
            services.AddMassTransitHostedService(true);

            //interfaces
            //client
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IClientService, ClientService>();

            //order
            services.AddSingleton<IOrderRepository, OrderRepository>();

            RepoDb.SqlServerBootstrap.Initialize();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gruppo3.Clienti.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

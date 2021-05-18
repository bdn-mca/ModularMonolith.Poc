using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModularMonolith.Infrastructure.EventBus;
using Module1.Application.Startup;
using Module2.Application.Startup;

namespace ModularMonolith.Poc.API
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

            // so we can have controllers in the separate modules instead all controllers in the API project
            services.AddMvc().AddApplicationPart(typeof(Module1.Application.ExecuteController).Assembly).AddControllersAsServices();
            services.AddMvc().AddApplicationPart(typeof(Module2.Application.OrderController).Assembly).AddControllersAsServices();

            //event bus setup with: https://masstransit-project.com/
            services.AddScoped<IEventBusDispatcher, EventBusDispatcher>();

            services.AddMassTransit(x =>
            {
                x.RegisterModuleOneConsumers();
                x.RegisterModuleTwoConsumers();

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingInMemory((context, cfg) =>
                {
                    cfg.UseMessageRetry(retryConfiguration =>
                    {
                        retryConfiguration.Intervals(2000, 4000, 10000); // in ms
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
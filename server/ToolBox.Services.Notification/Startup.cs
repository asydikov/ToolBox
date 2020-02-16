using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToolBox.Common.Auth;
using ToolBox.Common.Events;
using ToolBox.Common.RabbitMq;
using ToolBox.Services.Notification.Handlers;
using ToolBox.Services.Notification.Hubs;
using ToolBox.Services.Notification.Messages.Events;
using ToolBox.Services.Notification.Services;

namespace ToolBox.Services.Notification
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
            services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddSignalR();
            services.AddScoped<IHubService, HubService>();
            services.AddScoped<IHubWrapper, HubWrapper>();
            services.AddScoped<IEventHandler<OperationCompleted>, OperationCompletedHandler>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notification");
            });
        }
    }
}

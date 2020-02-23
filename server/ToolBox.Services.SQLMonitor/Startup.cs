using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToolBox.Common.Events;
using ToolBox.Common.RabbitMq;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.EF;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Handlers;
using ToolBox.Services.SQLMonitor.Helpers;
using ToolBox.Services.SQLMonitor.Messages.Events;
using ToolBox.Services.SQLMonitor.Repositories;
using ToolBox.Services.SQLMonitor.Services;

namespace ToolBox.Services.SQLMonitor
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
            var sql = Configuration.GetSection("sql");
            services.AddControllers();
            services.AddHostedService<TimedHostedService>();
            services.AddRabbitMq(Configuration);
            services.Configure<SqlSettings>(sql);
            services.AddEntityFrameworkSqlServer().AddDbContext<SQLMonitorDbContext>();
            services.AddScoped<IEventHandler<DbWorkerOperationCompleted>, DbWorkerOperationCompletedHandler>();
            services.AddScoped<IEventHandler<DbWorkerOperationRejected>, DbWorkerOperationRejectedHandler>();
            services.AddScoped<IMetrics, Metrics>();

            services.AddScoped<IRepositoryBase<SQLQuery>, RepositoryBase<SQLQuery>>();
            services.AddScoped<IServiceBase<SQLQueryModel>, ServiceBase<SQLQueryModel, SQLQuery>>();
            services.AddScoped<ISQLQueryService, SQLQueryService>();
            services.AddScoped<ISQLQueryRepository, SQLQueryRepository>();

            services.AddScoped<IMapper>(_ => AutoMapperConfig.GetMapper());

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

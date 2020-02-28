using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Toolbox.Common.RestEase;
using ToolBox.Common.Commands;
using ToolBox.Common.Events;
using ToolBox.Common.RabbitMq;
using ToolBox.Services.SQLMonitor.Domain.Models;
using ToolBox.Services.SQLMonitor.EF;
using ToolBox.Services.SQLMonitor.Entities;
using ToolBox.Services.SQLMonitor.Handlers;
using ToolBox.Services.SQLMonitor.Handlers.DbWorker;
using ToolBox.Services.SQLMonitor.Helpers;
using ToolBox.Services.SQLMonitor.Messages.Commands;
using ToolBox.Services.SQLMonitor.Messages.Events;
using ToolBox.Services.SQLMonitor.Messages.Events.DbWorker;
using ToolBox.Services.SQLMonitor.Repositories;
using ToolBox.Services.SQLMonitor.RestEaseServices;
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
            //         services.AddMvc()
            //.AddJsonOptions(
            //    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //); ;
            //services.RegisterRestEaseService<IIdentityService>("identity-service");
            services.RegisterRestEaseService<IDbWorkerService>("dbworker-service");

            services.AddEntityFrameworkSqlServer().AddDbContext<SqlMonitorDbContext>();
            services.AddScoped<IEventHandler<DbWorkerOperationCompleted>, DbWorkerOperationCompletedHandler>();
            services.AddScoped<IEventHandler<DbWorkerOperationRejected>, DbWorkerOperationRejectedHandler>();
            services.AddScoped<ICommandHandler<ServerCommand>, CheckServerConnectionHandler>();
            services.AddScoped<IMetrics, Metrics>();

            services.AddScoped<IRepositoryBase<SqlQuery>, RepositoryBase<SqlQuery>>();
            services.AddScoped<IServiceBase<SqlQueryModel, SqlQuery>, ServiceBase<SqlQueryModel, SqlQuery>>();
            services.AddScoped<IRepositoryBase<Server>, RepositoryBase<Server>>();
            services.AddScoped<IServiceBase<ServerModel, Server>, ServiceBase<ServerModel, Server>>();
            services.AddScoped<IRepositoryBase<Database>, RepositoryBase<Database>>();
            services.AddScoped<IServiceBase<DatabaseModel, Database>, ServiceBase<DatabaseModel, Database>>();
            services.AddScoped<IRepositoryBase<Schedule>, RepositoryBase<Schedule>>();
            services.AddScoped<IServiceBase<ScheduleModel, Schedule>, ServiceBase<ScheduleModel, Schedule>>();

            services.AddScoped<ISqlQueryService, SqlQueryService>();
            services.AddScoped<ISqlQueryRepository, SqlQueryRepository>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<IServerRepository, ServerRepository>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

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


            //{
            //    using (var scope = app.ApplicationServices.CreateScope())
            //    {
            //        var metricsService =
            //           scope.ServiceProvider
            //               .GetRequiredService<IMetrics>();

            //        metricsService.DoWork();
            //    }
            //}
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToolBox.Common.Commands;
using ToolBox.Common.RabbitMq;
using ToolBox.Services.DBWorker.Handlers;
using ToolBox.Services.DBWorker.Messages.Commands;
using ToolBox.Services.DBWorker.Services;

namespace ToolBox.Services.DBWorker
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
            services.AddRabbitMq(Configuration);
            services.AddScoped<ISQLService, SqlService>();
            services.AddScoped<ICommandHandler<SqlStatementQuery>, SqlStatementQueryHandler>();
            services.AddScoped<ICommandHandler<SqlStoredProcedureQuery>, SqlStoredProcedureQueryHandler>();
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

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToolBox.Common.Auth;
using ToolBox.Common.Commands;
using ToolBox.Common.RabbitMq;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.EF;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Handlers;
using ToolBox.Services.Identity.Messages.Commands;
using ToolBox.Services.Identity.MIddlewares;
using ToolBox.Services.Identity.Repositories;
using ToolBox.Services.Identity.Services;

namespace ToolBox.Services.Identity
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
            var jwt = Configuration.GetSection("jwt");
            var sql = Configuration.GetSection("sql");
            services.AddControllers();
            services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            services.Configure<SqlSettings>(sql);
            services.AddEntityFrameworkSqlServer().AddDbContext<IdentityDbContext>();
            services.AddScoped<ICommandHandler<SignUp>, SignUpHandler>();
            services.AddScoped<ICommandHandler<ChangePassword>, ChangePasswordHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<IClaimsProvider, ClaimsProvider>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
           
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

            app.UseAuthentication();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

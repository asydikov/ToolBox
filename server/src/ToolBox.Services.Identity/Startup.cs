using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ToolBox.Common.Auth;
using ToolBox.Common.Commands;
using ToolBox.Common.Commands.IdentityService;
using ToolBox.Common.Events;
using ToolBox.Common.RabbitMq;
using ToolBox.Services.Identity.Domain.Repositories;
using ToolBox.Services.Identity.EF;
using ToolBox.Services.Identity.Entities;
using ToolBox.Services.Identity.Handlers;
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
            services.AddScoped<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddTransient<IAccessTokenService, AccessTokenService>();
            services.AddTransient<IClaimsProvider, ClaimsProvider>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

            // services.AddTransient<AccessTokenValidatorMiddleware>();

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
            app.UseAuthentication();
            // app.UseMiddleware<AccessTokenValidatorMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

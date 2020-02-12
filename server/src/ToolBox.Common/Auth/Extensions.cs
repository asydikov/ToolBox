using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ToolBox.Common.Auth
{
    public static class Extensions
    {

        //            private readonly JwtOptions _options;
        // IOptions<JwtOptions> options
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new JwtOptions();
            var section = configuration.GetSection("jwt");
            section.Bind(options);
            services.Configure<JwtOptions>(configuration.GetSection("jwt"));
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                        ValidIssuer = options.Issuer,
                        ValidateLifetime = options.ValidateLifetime,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }


        // services.AddAuthentication(x =>
        //            {
        //                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //            })
        //            .AddJwtBearer(x =>
        //            {
        //                x.RequireHttpsMetadata = false;
        //                x.SaveToken = true;
        //                x.TokenValidationParameters = new TokenValidationParameters
        //                {
        //                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        //                         Configuration.GetSection("jwt")
        //                         .GetValue<string>("secretKey"))),
        //                    ValidIssuer = Configuration.GetSection("jwt").GetValue<string>("issuer"),
        //                    ValidateAudience = false,
        //                    ValidateIssuer = false
        //                };

        //            });
    }
}
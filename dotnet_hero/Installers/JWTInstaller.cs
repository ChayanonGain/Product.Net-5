using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_hero.Installers
{
    public class JWTInstaller : IInstallers
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var jwtsetting = new JwtSetting();
            configuration.Bind(nameof(jwtsetting), jwtsetting);
            services.AddSingleton(jwtsetting);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtsetting.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtsetting.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsetting.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public class JwtSetting
        {

            public string Key { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string Expire { get; set; }
        }
    }

}
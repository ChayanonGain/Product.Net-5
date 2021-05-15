using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_hero.Installers
{
    public class CORSInstaller : IInstallers
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => 
                {
                    builder.WithOrigins(
                        "https://www.w3schools.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

                options.AddPolicy("AllowAllOrigin", builder => 
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
    }
}
using System.ComponentModel.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_hero.Installers
{
    public interface IInstallers
    {
         void InstallService(IServiceCollection services , IConfiguration configuration);
    }
}
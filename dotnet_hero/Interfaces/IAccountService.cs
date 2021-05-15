using System.Threading.Tasks;
using dotnet_hero.Entities;

namespace dotnet_hero.Interfaces
{
    public interface IAccountService
    {
         Task Register(Account account);

         Task<Account> Login(string username, string password);
    }
}
using System.Security.Cryptography;
using System;
using System.Threading.Tasks;
using dotnet_hero.Data;
using dotnet_hero.Entities;
using dotnet_hero.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace dotnet_hero.Services
{
    public class AccountService : IAccountService
    {
        private readonly DatabaseContext databaseContext;
        public AccountService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Register(Account account)
        {
            var CheckAccount = await databaseContext.Accounts.SingleOrDefaultAsync(a => a.Username == account.Username);
            if(CheckAccount != null)
            {
                throw new Exception("Account is use");
            }
            account.Password = CreatePasswordHash(account.Password);
            databaseContext.Accounts.Add(account);
            await databaseContext.SaveChangesAsync();
        }
         public async Task<Account> Login(string username, string password)
        {
            var account = await databaseContext.Accounts.Include(a => a.Role)
            .SingleOrDefaultAsync(a => a.Username == username);

            if(account != null && VerifyPassword(account.Password , password))
            {
                return account;
            }

            return null;
        }

        private string CreatePasswordHash(string password)
        {
            byte[] salt = new byte[128/8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt : salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 258/8
            ));

            return $"{Convert.ToBase64String(salt)}.{hashed}" ;
        }

        private bool VerifyPassword(string hash, string password)
        {
            var parts = hash.Split('.', 2);
            if(parts.Length != 2)
            {
                return false;
            }
            var salt = Convert.FromBase64String(parts[0]);
            var passwordHash = parts[1];
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt : salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 258/8
            ));

            return passwordHash == hashed;
        }
    }
}
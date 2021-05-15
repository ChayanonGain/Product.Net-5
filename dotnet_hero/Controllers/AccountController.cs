using System.Net;
using System.Collections;
using dotnet_hero.DTOs.Account;
using dotnet_hero.Entities;
using dotnet_hero.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnet_hero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Register([FromForm] RegisterRequest registerRequest)
        {
            var account = registerRequest.Adapt<Account>();
            await accountService.Register(account);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login([FromForm] LoginRequest loginRequest)
        {
            var account = await accountService.Login(loginRequest.Username , loginRequest.Password);
            if(account == null)
            {
                return Unauthorized();
            }
            return Ok(new {token = "asdsadafasdfaf"});
        }
        
    }
}
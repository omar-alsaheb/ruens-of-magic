using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository<PlayerAccount> accountRepository;

        public AccountController(IAccountRepository<PlayerAccount> _accountRepository)
        {
            accountRepository = _accountRepository;
        }
        [HttpPost("AddNewAccount")]
        public async Task<IActionResult> AddNewAccount(PlayerAccount player)
        {

            var acc = await accountRepository.AddNewAccount(player);
            return Ok(acc);
        }

        [HttpGet("GetAllPlayers")]

        public async Task<ActionResult<IList<PlayerAccount>>> GetAllPlayer()
        {
            var omar = await accountRepository.GetAllPlayer();
            return Ok(omar);

        }


    }
}

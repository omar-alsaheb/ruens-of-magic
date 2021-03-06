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
        private readonly IRomRepository<PlayerAccount> romRepository;

        public AccountController(IRomRepository<PlayerAccount> _accountRepository)
        {
            romRepository = _accountRepository;
        }
        [HttpPost("AddNewAccount")]
        public async Task<IActionResult> AddNewAccount(PlayerAccount player)
        {

            var acc = await romRepository.AddNewAccount(player);
            return Ok(acc);
        }

        [HttpGet("GetAllPlayers")]

        public async Task<ActionResult<IList<PlayerAccount>>> GetAllPlayer()
        {
            var res = await romRepository.GetAllPlayer();
            return Ok(res);

        }

        [HttpGet("GetRoleDataBoard/{id}")]
        public async Task<ActionResult<IList<RoleDataBillBoardInfoViewModel>>> GetRoleDataBoard(int id)
        {
           return await romRepository.GetRoleDataBoard(id);
        }



    }
}

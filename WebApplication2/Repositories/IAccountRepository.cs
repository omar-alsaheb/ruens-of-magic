using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IAccountRepository<T>
    {
        public Task<PlayerAccountReturnModel> AddNewAccount(PlayerAccount playerAccount);
        public Task<ActionResult<IList<PlayerAccount>>> GetAllPlayer();
    }
}

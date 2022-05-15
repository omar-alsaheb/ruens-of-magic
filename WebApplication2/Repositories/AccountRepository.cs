using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Db;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class AccountRepository : IAccountRepository<PlayerAccount>
    {
        private readonly AppDbContext appDb;

        public AccountRepository(AppDbContext _appDb)
        {
            appDb = _appDb;
        }
        public async Task<PlayerAccountReturnModel> AddNewAccount(PlayerAccount playerAccount)
        {
            var exist = appDb.PlayerAccount.Any(x => x.Account_ID == playerAccount.Account_ID);
            var account = new PlayerAccount {
                
                Account_ID = playerAccount.Account_ID,
                Password = playerAccount.Password,
                IsMd5Password = playerAccount.IsMd5Password,
                IsAutoConvertMd5= playerAccount.IsAutoConvertMd5

            };
            if (exist)
            {
                return new PlayerAccountReturnModel { IsSuccess = false, Error = "Account is already exist" };
            }
            else
            {
                appDb.Add(playerAccount);
                await appDb.SaveChangesAsync();
                return new PlayerAccountReturnModel { IsSuccess = true, PlayerAccount = playerAccount, Error = string.Empty };
            }
        }

        public async Task<ActionResult<IList<PlayerAccount>>> GetAllPlayer()
        {
              return await appDb.PlayerAccount.ToListAsync();
        }


    }
}

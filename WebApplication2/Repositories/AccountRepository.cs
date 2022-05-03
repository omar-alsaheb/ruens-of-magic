using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<PlayerAccount> AddNewAccount(PlayerAccount playerAccount)
        {
            var account = new PlayerAccount {
                
                Account_ID = playerAccount.Account_ID,
                Password = playerAccount.Password,
                IsMd5Password = playerAccount.IsMd5Password,
                IsAutoConvertMd5= playerAccount.IsAutoConvertMd5

            };
            appDb.Add(playerAccount);
            await appDb.SaveChangesAsync();
            return account;
        }

        public async Task<ActionResult<IList<PlayerAccount>>> GetAllPlayer()
        {
              return await appDb.PlayerAccount.ToListAsync();
        }


    }
}

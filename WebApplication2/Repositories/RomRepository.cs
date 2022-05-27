using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Db;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class RomRepository : IRomRepository<PlayerAccount>
    {
        private readonly ROM_Account appDb;
        private readonly ROM_World rom_World;

        public RomRepository(ROM_Account _appDb, ROM_World _rom_World)
        {
            appDb = _appDb;
            rom_World = _rom_World;
        }
        public async Task<PlayerAccountReturnModel> AddNewAccount(PlayerAccount playerAccount)
        {
            var exist = appDb.PlayerAccount.Any(x => x.Account_ID == playerAccount.Account_ID);
            var account = new PlayerAccount
            {

                Account_ID = playerAccount.Account_ID,
                Password = playerAccount.Password,
                IsMd5Password = playerAccount.IsMd5Password,
                IsAutoConvertMd5 = playerAccount.IsAutoConvertMd5

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

        public async Task<ActionResult<IList<RoleDataBillBoardInfoViewModel>>> GetRoleDataBoard(int id)
        {
            var TypeNameDynamic = "";

            if (id == 3)
            {
                TypeNameDynamic = "Strength";
            }
            if (id == 4)
            {
                TypeNameDynamic = "Dexterity";
            }
            if (id == 5)
            {
                TypeNameDynamic = "Stamina";
            }
            if (id == 6)
            {
                TypeNameDynamic = "intelligence";
            }
            if (id == 7)
            {
                TypeNameDynamic = "Wisdom";
            }
            if (id == 8)
            {
                TypeNameDynamic = "Melee Attack";
            }
            if (id == 9)
            {
                TypeNameDynamic = "Magic Attack";
            }
            if (id == 10)
            {
                TypeNameDynamic = "Physical Defense";
            }
            if (id == 11)
            {
                TypeNameDynamic = "Magical Defense";
            }

            var  query =  (from bill in rom_World.BillBoardInfo
                         join role in rom_World.RoleData on bill.PlayerDBID equals role.DBID
                         orderby bill.SortValue descending
                           where bill.Type == id
                           select new 
                         {
                             RANK = bill.SortValue,
                             PlayerDBID = bill.PlayerDBID,
                             RoleName= role.RoleName.Replace('\u0000',' '),
                             Type = bill.Type
                         }).Take(15).ToList();

            var result = new List<RoleDataBillBoardInfoViewModel>();
            foreach (var item in query)
            {
                result.Add(new RoleDataBillBoardInfoViewModel()
                {
                    DBID =  item.PlayerDBID,
                    RoleName = item.RoleName,
                    RANK = item.RANK,
                    Type = item.Type,
                    TypeName = TypeNameDynamic
                });

            }

            return result;

        }


    }
}

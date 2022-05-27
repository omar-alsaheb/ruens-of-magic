﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<ActionResult<IList<RoleDataBillBoardInfoViewModel>>> GetRoleDataBoard()
        {


            var  query =  (from bill in rom_World.BillBoardInfo
                         join role in rom_World.RoleData on bill.PlayerDBID equals role.DBID
                         orderby bill.SortValue
                         where bill.Type == 4
                         select new 
                         {
                             RANK = bill.SortValue,
                             PlayerDBID = bill.PlayerDBID,
                             RoleName= role.RoleName,
                             PhysicalDefense = bill.Type
                         }).ToList();

            var result = new List<RoleDataBillBoardInfoViewModel>();
            foreach (var item in query)
            {
                result.Add(new RoleDataBillBoardInfoViewModel()
                {
                    DBID =  item.PlayerDBID,
                    RoleName = item.RoleName,
                    RANK = item.RANK

                });

            }

            return result;

        }
    }
}
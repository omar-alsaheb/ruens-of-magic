using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Db
{
    public class ROM_World: DbContext
    {
        public ROM_World(DbContextOptions<ROM_World> options) : base(options)

        {

        }

        public DbSet<RoleData> RoleData { get; set; }
        public DbSet<BillBoardInfo> BillBoardInfo { get; set; }

    }
}

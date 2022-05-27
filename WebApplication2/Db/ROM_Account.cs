using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Db
{
    public class ROM_Account:DbContext
    {
        public ROM_Account(DbContextOptions<ROM_Account> options) : base(options)

        {

        }
        public DbSet<PlayerAccount> PlayerAccount { get; set; }
    }
}

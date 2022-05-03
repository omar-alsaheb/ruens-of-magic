using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Db
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {

        }
        public DbSet<PlayerAccount> PlayerAccount { get; set; }
    }
}

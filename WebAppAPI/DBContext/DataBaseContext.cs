using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models;

namespace WebAppAPI.DatabaseContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) 
            : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }



}
}

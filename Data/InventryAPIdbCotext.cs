
using InventrySystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventrySystemAPI.Data
{
    public class InventryAPIdbCotext : DbContext
    {
        public InventryAPIdbCotext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Items> Items { get; set; }
        public DbSet<Bills> Bills { get; set; }

    }
}

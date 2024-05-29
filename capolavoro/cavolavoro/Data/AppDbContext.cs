using cavolavoro.Models;
using Microsoft.EntityFrameworkCore;

namespace cavolavoro.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Valuta> Valute { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NomeDelTuoDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}

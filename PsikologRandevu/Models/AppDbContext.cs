using Microsoft.EntityFrameworkCore;

namespace PsikologRandevu.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Psikolog> Psikologlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<GorusmeNotu> GorusmeNotlari { get; set; }
    }
}
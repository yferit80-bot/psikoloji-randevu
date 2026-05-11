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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Hasta)
                .WithMany()
                .HasForeignKey(r => r.HastaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Psikolog)
                .WithMany()
                .HasForeignKey(r => r.PsikologId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GorusmeNotu>()
                .HasOne(g => g.Randevu)
                .WithMany()
                .HasForeignKey(g => g.RandevuId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GorusmeNotu>()
                .HasOne(g => g.Psikolog)
                .WithMany()
                .HasForeignKey(g => g.PsikologId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
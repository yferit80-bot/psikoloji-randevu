using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PsikologRandevu.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doktor> Doktors { get; set; }

    public virtual DbSet<GorusmeNotlari> GorusmeNotlari { get; set; }

    public virtual DbSet<Hastalar> Hastalar { get; set; }

    public virtual DbSet<Hastum> Hasta { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }

    public virtual DbSet<Psikologlar> Psikologlar { get; set; }

    public virtual DbSet<Randevular> Randevular { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PsikologRandevuDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doktor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doktor__3214EC075465CB2E");

            entity.ToTable("Doktor");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Sifre).HasMaxLength(100);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.Uzmanlik).HasMaxLength(100);
        });

        modelBuilder.Entity<GorusmeNotlari>(entity =>
        {
            entity.ToTable("GorusmeNotlari");

            entity.HasIndex(e => e.PsikologId, "IX_GorusmeNotlari_PsikologId");

            entity.HasIndex(e => e.RandevuId, "IX_GorusmeNotlari_RandevuId");

            entity.HasOne(d => d.Psikolog).WithMany(p => p.GorusmeNotlaris)
                .HasForeignKey(d => d.PsikologId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Randevu).WithMany(p => p.GorusmeNotlaris)
                .HasForeignKey(d => d.RandevuId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Hastalar>(entity =>
        {
            entity.ToTable("Hastalar");

            entity.HasIndex(e => e.KullaniciId, "IX_Hastalar_KullaniciId");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Hastalars).HasForeignKey(d => d.KullaniciId);
        });

        modelBuilder.Entity<Hastum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hasta__3214EC07366AE0D1");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Sifre).HasMaxLength(100);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.TcNo).HasMaxLength(11);
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.ToTable("Kullanicilar");
        });

        modelBuilder.Entity<Psikologlar>(entity =>
        {
            entity.ToTable("Psikologlar");

            entity.HasIndex(e => e.KullaniciId, "IX_Psikologlar_KullaniciId");

            entity.Property(e => e.SeansUcreti).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Kullanici).WithMany(p => p.Psikologlars).HasForeignKey(d => d.KullaniciId);
        });

        modelBuilder.Entity<Randevular>(entity =>
        {
            entity.ToTable("Randevular");

            entity.HasIndex(e => e.HastaId, "IX_Randevular_HastaId");

            entity.HasIndex(e => e.PsikologId, "IX_Randevular_PsikologId");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Randevulars)
                .HasForeignKey(d => d.HastaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Psikolog).WithMany(p => p.Randevulars)
                .HasForeignKey(d => d.PsikologId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

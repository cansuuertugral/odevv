using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OgrenciBilgiSistemi
{
    public class OdevDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<OgrenciDers> OgrenciDersler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data source=localhost;Initial Catalog =OdevDB; Integrated Security=true; TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).HasColumnType("varchar").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Sinif>().HasKey(s => s.SinifId);
            modelBuilder.Entity<Sinif>().Property(s => s.SinifAd).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Sinif>().Property(s => s.Kontenjan).IsRequired();
            modelBuilder.Entity<Dersler>().HasKey(d => d.DersId);
            modelBuilder.Entity<OgrenciDers>().HasKey(od => new { od.OgrenciId, od.DersId });
            modelBuilder.Entity<OgrenciDers>().HasOne(od => od.Ogrenci).WithMany(o => o.OgrenciDers).HasForeignKey(od => od.OgrenciId);
            modelBuilder.Entity<OgrenciDers>().HasOne(od => od.Ders).WithMany(d => d.OgrenciDersler).HasForeignKey(od => od.DersId);

        }
    }
}

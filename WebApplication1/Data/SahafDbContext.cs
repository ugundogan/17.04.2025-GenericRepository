using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class SahafDbContext : DbContext
{
    public SahafDbContext()
    {
    }

    public SahafDbContext(DbContextOptions<SahafDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategori> Kategoriler { get; set; }

    public virtual DbSet<Kitap> Kitaplar { get; set; }

    public virtual DbSet<YayinEvi> YayinEvleri { get; set; }

    public virtual DbSet<Yazar> Yazarlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = .; initial catalog = SahafDb; integrated security = true; trust server certificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kitap>(entity =>
        {
            entity.HasKey(e => e.KitapId);

            entity.ToTable("Kitaplar");

            entity.HasIndex(e => e.KategoriId, "IX_Kitaplar_KategoriID");

            entity.HasIndex(e => e.YayinEviId, "IX_Kitaplar_YayinEviID");

            entity.HasIndex(e => e.YazarId, "IX_Kitaplar_YazarID");

            entity.Property(e => e.KitapId).HasColumnName("KitapID");
            entity.Property(e => e.Fiyat).HasColumnType("money");
            entity.Property(e => e.KapakResmi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("bos.jpg");
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.KitapAdi)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.YayinEviId).HasColumnName("YayinEviID");
            entity.Property(e => e.YazarId).HasColumnName("YazarID");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Kitaplar).HasForeignKey(d => d.KategoriId);

            entity.HasOne(d => d.YayinEvi).WithMany(p => p.Kitaplar).HasForeignKey(d => d.YayinEviId);

            entity.HasOne(d => d.Yazar).WithMany(p => p.Kitaplar).HasForeignKey(d => d.YazarId);
        });

        modelBuilder.Entity<YayinEvi>(entity =>
        {
            entity.HasKey(e => e.YayinEviId);

            entity.ToTable("YayinEvleri");

            entity.Property(e => e.YayinEviId).HasColumnName("YayinEviID");
        });

        modelBuilder.Entity<Yazar>(entity =>
        {
            entity.HasKey(e => e.YazarId);

            entity.ToTable("Yazarlar");

            entity.Property(e => e.YazarId).HasColumnName("YazarID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ingatlan.Models
{
    public partial class ingatlanContext : DbContext
    {
        public ingatlanContext()
        {
        }

        public ingatlanContext(DbContextOptions<ingatlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingatlanok> Ingatlanoks { get; set; } = null!;
        public virtual DbSet<Kategoriak> Kategoriaks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=ingatlan;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingatlanok>(entity =>
            {
                entity.ToTable("ingatlanok");

                entity.HasIndex(e => e.Kategoria, "kategoria");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Ar)
                    .HasColumnType("int(11)")
                    .HasColumnName("ar");

                entity.Property(e => e.HirdetesDatuma)
                    .HasColumnType("date")
                    .HasColumnName("hirdetesDatuma")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Kategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("kategoria");

                entity.Property(e => e.KepUrl)
                    .HasMaxLength(240)
                    .HasColumnName("kepUrl");

                entity.Property(e => e.Leiras)
                    .HasMaxLength(420)
                    .HasColumnName("leiras");

                entity.Property(e => e.Tehermentes).HasColumnName("tehermentes");

                entity.HasOne(d => d.KategoriaNavigation)
                    .WithMany(p => p.Ingatlanoks)
                    .HasForeignKey(d => d.Kategoria)
                    .HasConstraintName("ingatlanok_ibfk_1");
            });

            modelBuilder.Entity<Kategoriak>(entity =>
            {
                entity.ToTable("kategoriak");

                entity.HasIndex(e => e.Nev, "nev_index")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nev)
                    .HasMaxLength(100)
                    .HasColumnName("nev");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

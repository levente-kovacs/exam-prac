using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SuliVerseny.Models
{
    public partial class VersenyContext : DbContext
    {
        public VersenyContext()
        {
        }

        public VersenyContext(DbContextOptions<VersenyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Felhasznalok> Felhasznaloks { get; set; }
        public virtual DbSet<Iskolak> Iskolaks { get; set; }
        public virtual DbSet<Iskolalogok> Iskolalogoks { get; set; }
        public virtual DbSet<Registry> Registries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=Verseny;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Felhasznalok>(entity =>
            {
                entity.ToTable("felhasznalok");

                entity.HasIndex(e => e.Email, "Email")
                    .IsUnique();

                entity.HasIndex(e => e.FelhasznaloNev, "FelhasznaloNev")
                    .IsUnique();

                entity.HasIndex(e => e.IskolaId, "iskolaId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Aktiv).HasColumnType("int(1)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FelhasznaloNev)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("HASH");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("imagePath");

                entity.Property(e => e.IskolaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("iskolaId");

                entity.Property(e => e.Jogosultsag).HasColumnType("int(1)");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SALT");

                entity.Property(e => e.TeljesNev)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Iskola)
                    .WithMany(p => p.Felhasznaloks)
                    .HasPrincipalKey(p => p.IskolaId)
                    .HasForeignKey(d => d.IskolaId)
                    .HasConstraintName("felhasznalok_ibfk_1");
            });

            modelBuilder.Entity<Iskolak>(entity =>
            {
                entity.ToTable("iskolak");

                entity.HasIndex(e => e.IskolaId, "iskolaId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IskolaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("iskolaId");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("nev");
            });

            modelBuilder.Entity<Iskolalogok>(entity =>
            {
                entity.ToTable("iskolalogok");

                entity.HasIndex(e => e.IskolaId, "iskolaId")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IskolaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("iskolaId");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("mediumblob")
                    .HasColumnName("logo");

                entity.HasOne(d => d.Iskola)
                    .WithOne(p => p.Iskolalogok)
                    .HasPrincipalKey<Iskolak>(p => p.IskolaId)
                    .HasForeignKey<Iskolalogok>(d => d.IskolaId)
                    .HasConstraintName("iskolalogok_ibfk_1");
            });

            modelBuilder.Entity<Registry>(entity =>
            {
                entity.ToTable("registry");

                entity.HasIndex(e => e.Key, "key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FelhasznaloNev)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("HASH");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("SALT");

                entity.Property(e => e.TeljesNev)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Epsi_Festival.Models
{
    public partial class Festival_EPSIContext : DbContext
    {
        public Festival_EPSIContext()
        {
        }

        public Festival_EPSIContext(DbContextOptions<Festival_EPSIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Artiste> Artistes { get; set; } = null!;
        public virtual DbSet<Programmation> Programmations { get; set; } = null!;
        public virtual DbSet<Scene> Scenes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=bddindus-test;Database=Festival;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Artiste>(entity =>
            {
                entity.ToTable("artiste");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Programmation>(entity =>
            {
                entity.ToTable("programmation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArtisteId).HasColumnName("artiste_id");

                entity.Property(e => e.Heure)
                    .HasColumnType("datetime")
                    .HasColumnName("heure");

                entity.Property(e => e.SceneId).HasColumnName("scene_id");

                entity.HasOne(d => d.Artiste)
                    .WithMany(p => p.Programmations)
                    .HasForeignKey(d => d.ArtisteId)
                    .HasConstraintName("FK_programmation_artiste");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.Programmations)
                    .HasForeignKey(d => d.SceneId)
                    .HasConstraintName("FK_programmation_scene1");
            });

            modelBuilder.Entity<Scene>(entity =>
            {
                entity.ToTable("scene");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

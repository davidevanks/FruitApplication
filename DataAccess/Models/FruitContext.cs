using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Models
{
    public partial class FruitContext : DbContext
    {
        public FruitContext()
        {
        }

        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<FruitType> FruitTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.ToTable("Fruit");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Fruits)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Fruit_FruitType");
            });

            modelBuilder.Entity<FruitType>(entity =>
            {
                entity.ToTable("FruitType");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

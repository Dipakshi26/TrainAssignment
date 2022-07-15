using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Train.Data.Models
{
    public partial class OrderEFDbContext : DbContext
    {
        public OrderEFDbContext()
        {
        }

        public OrderEFDbContext(DbContextOptions<OrderEFDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TrainDay> TrainDays { get; set; } = null!;
        public virtual DbSet<TrainInfo> TrainInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-P3O2VMI\\SQLEXPRESS;Database=OrderEFDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainDay>(entity =>
            {
                entity.HasKey(e => e.TrainNumber);

                entity.ToTable("TrainDay");

                entity.Property(e => e.TrainNumber).ValueGeneratedNever();

                entity.HasOne(d => d.TrainNumberNavigation)
                    .WithOne(p => p.TrainDay)
                    .HasForeignKey<TrainDay>(d => d.TrainNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainDay_TrainInfo");
            });

            modelBuilder.Entity<TrainInfo>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.ToTable("TrainInfo");

                entity.Property(e => e.TrainNo).ValueGeneratedNever();

                entity.Property(e => e.FromStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JourneyEndTime).HasColumnType("date");

                entity.Property(e => e.JourneyStartTime).HasColumnType("date");

                entity.Property(e => e.ToStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

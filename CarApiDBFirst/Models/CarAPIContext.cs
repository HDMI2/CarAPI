using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//-- Scaffold-DbContext "Server=DHDEAB-L001;Database=CarAPI;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

namespace CarApiDBFirst.Models
{
    public partial class CarAPIContext : DbContext
    {
        public CarAPIContext()
        {
        }

        public CarAPIContext(DbContextOptions<CarAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarSet> CarSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DHDEAB-L001;Database=CarAPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarSet>(entity =>
            {
                entity.Property(e => e.Idnummer).HasColumnName("IDNummer");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRental.Models
{
    public partial class ProductDatabaseContext : DbContext
    {
        public virtual DbSet<Booked> Booked { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2ABQD7D\SQLEXPRESS;Database=ProductDatabase;Integrated Security=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booked>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CarHireDate)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CusFirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CusLastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DueDate)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
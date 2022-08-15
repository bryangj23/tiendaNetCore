using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AdminTienda.Models;

namespace AdminTienda.Context
{
    public partial class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<DetailSale> DetailSales { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<TypeDocument> TypeDocuments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.Name, "UQ__Category__72E12F1BDA468DC7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstSurname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("firstSurname");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumDocument)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("num_document");

                entity.Property(e => e.SecondSurname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("secondSurname");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telephone");

                entity.Property(e => e.TypeDocument)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("type_document");
            });

            modelBuilder.Entity<DetailSale>(entity =>
            {
                entity.ToTable("DetailSale");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdSale).HasColumnName("idSale");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DetailSales)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDPRODUCT");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.DetailSales)
                    .HasForeignKey(d => d.IdSale)
                    .HasConstraintName("FK_IDSALE");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.NameProd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nameProd");

                entity.Property(e => e.PriceSale)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("priceSale");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.isDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");                

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDCATEGORY");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateSale)
                    .HasColumnType("datetime")
                    .HasColumnName("dateSale");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TaxSale)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("taxSale");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(11, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDCLIENT");
            });

            modelBuilder.Entity<TypeDocument>(entity =>
            {
                entity.ToTable("TypeDocument");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        internal void SaveChanges(Product product)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

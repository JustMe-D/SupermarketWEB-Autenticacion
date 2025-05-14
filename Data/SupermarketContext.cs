using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;

namespace SupermarketWEB.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PayMode> PayModes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Restricciones únicas
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.document_number)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasIndex(i => i.number)
                .IsUnique();

            // Configuración de relaciones
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.customerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.PayMode)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.payModeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Invoice)
                .WithMany(i => i.Details)
                .HasForeignKey(d => d.invoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.Details)
                .HasForeignKey(d => d.productId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

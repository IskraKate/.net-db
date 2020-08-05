using Model.Elements;
using SalesNamespace.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace ModelNamespace
{
    class SalesContext : DbContext
    {
        public SalesContext() : base("Sales")
        {
            Database.SetInitializer(new SalesContextInitializer());
        }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Sales> SalesInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            // Sellers
            //
            modelBuilder.Entity<Seller>().HasKey(a => a.Id);
            modelBuilder.Entity<Seller>().Property(a=>a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Seller>().Property(a => a.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Seller>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<Seller>().Property(a => a.LastName).HasMaxLength(50);
            modelBuilder.Entity<Seller>().Property(a => a.LastName).IsRequired();

            modelBuilder.Entity<Seller>()
            .HasMany(a => a.Sales)
            .WithRequired(b => b.Seller)
            .HasForeignKey(b => b.SellerFk)
            .WillCascadeOnDelete();

            //
            //Buyers
            //
            modelBuilder.Entity<Buyer>().HasKey(a => a.Id);
            modelBuilder.Entity<Buyer>().Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Buyer>().Property(a => a.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Buyer>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<Buyer>().Property(a => a.LastName).HasMaxLength(50);
            modelBuilder.Entity<Buyer>().Property(a => a.LastName).IsRequired();

            modelBuilder.Entity<Buyer>()
            .HasMany(a => a.Sales)
            .WithRequired(b => b.Buyer)
            .HasForeignKey(b => b.BuyerFk)
            .WillCascadeOnDelete();

            //
            //Sales
            //
            modelBuilder.Entity<Sales>().ToTable("Sales");
            modelBuilder.Entity<Sales>().Property(b => b.Id).HasColumnName("Id");
            modelBuilder.Entity<Sales>().Property(b => b.Id).HasColumnType("bigint");
            modelBuilder.Entity<Sales>().HasKey(b => b.Id);
            modelBuilder.Entity<Sales>().Property(b => b.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Sales>().Property(b => b.Date).HasColumnType("date");
            modelBuilder.Entity<Sales>().Property(b => b.Date).IsRequired();
            modelBuilder.Entity<Sales>().Property(b => b.MoneySum).HasColumnType("decimal");

            base.OnModelCreating(modelBuilder);
        }

    }
}

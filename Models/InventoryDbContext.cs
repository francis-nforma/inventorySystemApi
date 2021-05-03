using System;
using inventoryApi.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace inventoryApi.Models
{
    public partial class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryTransactions> InventoryTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseNpgsql("CarsDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer>().Property(e => e.Dealer_Name).IsRequired();
            modelBuilder.Entity<Dealer>().Property(e => e.Address_Line1).IsRequired(false);
            modelBuilder.Entity<Dealer>().Property(e => e.Address_Line2).IsRequired(false);
            modelBuilder.Entity<Dealer>().Property(e => e.Address_Suburb).IsRequired(false);
            modelBuilder.Entity<Dealer>().Property(e => e.Address_State).IsRequired(false);
            modelBuilder.Entity<Dealer>().Property(e => e.Address_Postcode).IsRequired(false);
            modelBuilder.Entity<Dealer>().Property(e => e.Contact_Number).IsRequired(false);
            modelBuilder.Entity<Dealer>().Property(e => e.Active).IsRequired();
            modelBuilder.Entity<Dealer>().Property(e => e.Active).HasDefaultValue(true);
            modelBuilder.Entity<Dealer>().Property(e => e.Created_By).IsRequired();
            modelBuilder.Entity<Dealer>().Property(e => e.Created_By).HasDefaultValue(Environment.UserName);
            modelBuilder.Entity<Dealer>().Property(e => e.Created_Date).IsRequired();
            modelBuilder.Entity<Dealer>().Property(e => e.Created_Date).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Dealer>().Property(e => e.Last_Updated_Date).IsRequired(false);

            modelBuilder.Entity<Car>().Property(e => e.Make).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Model).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Series).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Year).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Active).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Active).HasDefaultValue(true);
            modelBuilder.Entity<Car>().Property(e => e.Created_By).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Created_By).HasDefaultValue(Environment.UserName);
            modelBuilder.Entity<Car>().Property(e => e.Created_Date).IsRequired();
            modelBuilder.Entity<Car>().Property(e => e.Created_Date).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Car>().Property(e => e.Last_Updated_Date).IsRequired(false);

            modelBuilder.Entity<Inventory>().Property(e => e.CarId).IsRequired();
            modelBuilder.Entity<Inventory>().Property(e => e.DealerId).IsRequired();
            modelBuilder.Entity<Inventory>().Property(e => e.Quantity).IsRequired();
            modelBuilder.Entity<Inventory>().Property(e => e.Created_By).IsRequired();
            modelBuilder.Entity<Inventory>().Property(e => e.Created_By).HasDefaultValue(Environment.UserName);
            modelBuilder.Entity<Inventory>().Property(e => e.Created_Date).IsRequired();
            modelBuilder.Entity<Inventory>().Property(e => e.Created_Date).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Inventory>().Property(e => e.Last_Updated_Date).IsRequired(false);

            modelBuilder.Entity<InventoryTransactions>().Property(e => e.CarId).IsRequired();
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.DealerId).IsRequired();
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.Event).IsRequired();
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.quantity).IsRequired();
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.Created_By).IsRequired();
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.Created_By).HasDefaultValue(Environment.UserName);
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.Created_Date).IsRequired();
            modelBuilder.Entity<InventoryTransactions>().Property(e => e.Created_Date).HasDefaultValue(DateTime.Now);


            modelBuilder.Entity<Inventory>().HasOne(c => c.Car)
                .WithMany(cd => cd.Inventory)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarDealer__Car");

            modelBuilder.Entity<Inventory>().HasOne(d => d.Dealer)
                .WithMany(cd => cd.Inventory)
                .HasForeignKey(d => d.DealerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarDealer__Dealer");


            modelBuilder.Entity<InventoryTransactions>().HasOne(c => c.Car)
                .WithMany(it => it.InventoryTransactions)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InventoryTransactions__Car");

            modelBuilder.Entity<InventoryTransactions>().HasOne(d => d.Dealer)
                .WithMany(it => it.InventoryTransactions)
                .HasForeignKey(d => d.DealerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InventoryTransactions__Dealer");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

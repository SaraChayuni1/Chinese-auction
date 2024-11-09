using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    
        public class OrdersContext : DbContext
        {
            public DbSet<Category> Category { get; set; }

            public DbSet<Customer> Customer { get; set; }

            public DbSet<Donor> Donor { get; set; }

            public DbSet<Present> Present { get; set; }
            public DbSet<Card> Card { get; set; }

            public DbSet<Purchase> Purchase { get; set; }
            public DbSet<Admanistrator> Admanistrator { get; set; }
            public OrdersContext(DbContextOptions<OrdersContext> contextOptions) : base(contextOptions)
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Customer>().Property(c => c.Id).UseIdentityColumn(0, 1);

                modelBuilder.Entity<Admanistrator>().Property(c => c.Id).UseIdentityColumn(0, 1);
          
                modelBuilder.Entity<Category>().Property(c => c.Id).UseIdentityColumn(0, 1);
           
                modelBuilder.Entity<Present>().Property(c => c.Id).UseIdentityColumn(0, 1);

            modelBuilder.Entity<Card>().Property(c => c.Id).UseIdentityColumn(0, 1);

            modelBuilder.Entity<Purchase>().Property(c => c.Id).UseIdentityColumn(0, 1);

                modelBuilder.Entity<Donor>().Property(c => c.Id).UseIdentityColumn(0, 1);
                base.OnModelCreating(modelBuilder);
            }
        }
}

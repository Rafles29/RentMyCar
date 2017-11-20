using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Model.DB
{
    public class RentMyAppContext : DbContext
    {
        public RentMyAppContext()
        {

        }
        public RentMyAppContext(DbContextOptions<RentMyAppContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Server = DESKTOP-AITKV2M; Database = RentMyCarDB; Trusted_Connection = True");
            }
        }
    }
}

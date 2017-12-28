using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Model.DB
{
    public class RentMyCarContext : DbContext
    {
        public RentMyCarContext(DbContextOptions<RentMyCarContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Model.DB
{
    public class RentMyCarContext : IdentityDbContext<User>
    {
        public RentMyCarContext(DbContextOptions<RentMyCarContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}

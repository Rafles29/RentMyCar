using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Model.DB
{
    public class Db : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = RentData; Trusted_Connection = True");
        }
    }
}

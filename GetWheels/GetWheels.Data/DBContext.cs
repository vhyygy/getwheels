using GetWheels.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetWheels.Data
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options) 
            : base (options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Location> Locations { get; set; }

    }
}

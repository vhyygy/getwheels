using GetWheels.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetWheels.Data
{
    public class GWContextDb : DbContext
    {
        public GWContextDb(DbContextOptions<GWContextDb> options) 
            : base (options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}

using CWhhelsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWhhelsApi.Data
{
    public class CWheelsDBContext : DbContext
    {
        public CWheelsDBContext(DbContextOptions<CWheelsDBContext> options) : base(options)
        {
        }
        
        // Maps our data base with the name provided in this case Vehicles
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}

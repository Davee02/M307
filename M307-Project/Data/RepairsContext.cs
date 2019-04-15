using M307_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M307_Project.Data
{
    public class RepairsContext : DbContext
    {
        public RepairsContext(DbContextOptions<RepairsContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<RepairOrder> RepairOrders { get; set; }

        public DbSet<Tool> Tools { get; set; }
    }
}

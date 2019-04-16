using M307_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace M307_Project.Data
{
    public class RepairsContext : DbContext
    {
        public RepairsContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<RepairOrder> RepairOrders { get; set; }

        public DbSet<Tool> Tools { get; set; }
    }
}

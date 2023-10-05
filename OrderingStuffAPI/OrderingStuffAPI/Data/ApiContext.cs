using Microsoft.EntityFrameworkCore;
using OrderingStuffAPI.Models;

namespace OrderingStuffAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<OrderingStuff> Orders { get; set; } 
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {

        }

    }
}

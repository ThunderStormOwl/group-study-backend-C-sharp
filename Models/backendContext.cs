using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class backendContext : DbContext
    {
        public backendContext(DbContextOptions<backendContext> options)
            : base(options)
        {
        }

        public DbSet<backendItem> backendItems { get; set; }
    }
}
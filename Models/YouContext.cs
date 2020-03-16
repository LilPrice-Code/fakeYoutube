using Microsoft.EntityFrameworkCore;

namespace Youapi.Models
{
    public class YouContext : DbContext
    {
        public YouContext(DbContextOptions<YouContext> options)
            : base(options)
        {
        }

        public DbSet<YouItem> YouItem { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace WebMarkReport.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<MarkReport> Reports { get; set; }
        public DbSet<Structure> Structures { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

using ResultsSummary.Models;

namespace ResultsSummary.services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }



        public DbSet<Result> Results { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using TutorialsOData.Models;

namespace TutorialsOData.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}

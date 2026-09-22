using Microsoft.EntityFrameworkCore;

namespace planningRecette.Infrastructure.Database
{
    public class PlanningRecetteDbContext : DbContext
    {
        public PlanningRecetteDbContext()
        {
        }

        public PlanningRecetteDbContext(DbContextOptions<PlanningRecetteDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PlanningRecette;Trusted_Connection=True;");
            }
        }
    }
}
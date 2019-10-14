using System.ComponentModel.DataAnnotations;
using System.Linq;
using Food.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Ingredient>()

        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                where e.State == EntityState.Added
                      || e.State == EntityState.Modified
                select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }

            return base.SaveChanges();
        }
    }
}

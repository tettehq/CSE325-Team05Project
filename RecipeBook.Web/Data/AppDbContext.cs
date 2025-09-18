using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Recipe> Recipes => Set<Recipe>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(r => r.Title).IsRequired().HasMaxLength(120);
                entity.Property(r => r.Category).HasMaxLength(60);
                entity.Property(r => r.ImagePath).HasMaxLength(255);
                entity.Property(r => r.Ingredients).IsRequired();
                entity.Property(r => r.Steps).IsRequired();
                entity.Property(r => r.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(r => r.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}

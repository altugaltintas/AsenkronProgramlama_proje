using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.Mapiing;
using Microsoft.EntityFrameworkCore;

namespace AsenkronProgramlama.Infrastructure.Context
{
    public class ApplicationDbContextcs: DbContext
    {
        public ApplicationDbContextcs(DbContextOptions<ApplicationDbContextcs> options) : base(options) { }

        public DbSet<Product>   Products { get; set; }
         
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
                base.OnModelCreating(modelBuilder);
        }


    }
}

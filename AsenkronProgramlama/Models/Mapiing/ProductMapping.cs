using AsenkronProgramlama.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsenkronProgramlama.Models.Mapiing
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryID);
        }
    }
}

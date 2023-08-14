using AsenkronProgramlama.Infrastructure.Context;
using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;

namespace AsenkronProgramlama.Infrastructure.Repositories.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContextcs contextcs) : base(contextcs)
        {
        }
    }
}

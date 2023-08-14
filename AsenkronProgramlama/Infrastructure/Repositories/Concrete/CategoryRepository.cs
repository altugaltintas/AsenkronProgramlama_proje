using AsenkronProgramlama.Infrastructure.Context;
using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;

namespace AsenkronProgramlama.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository

    {
        public CategoryRepository(ApplicationDbContextcs contextcs) : base(contextcs)
        {
        }
    }
}

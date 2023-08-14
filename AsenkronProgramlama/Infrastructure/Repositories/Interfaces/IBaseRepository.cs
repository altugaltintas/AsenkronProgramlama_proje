using AsenkronProgramlama.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task Add(T entity);

        Task Update(T entity);

        Task<T> GetById(int id);
        Task Delete(T entity);

        Task<List<T>> GetByDefaults(Expression<Func<T, bool>> expression);

        Task<T> GetByDefault(Expression<Func<T, bool>> expression);

        Task<List<TResult>> GetFilter<TResult>(Expression<Func<T, TResult>> selector,
                                               Expression<Func<T, bool>> expression,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);

    }
}

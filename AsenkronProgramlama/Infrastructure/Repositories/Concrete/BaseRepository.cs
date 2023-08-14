using AsenkronProgramlama.Infrastructure.Context;
using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Abstract;
using AsenkronProgramlama.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Infrastructure.Repositories.Concrete
{
   public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContextcs _context;
        private readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContextcs context)
        {
            _context = context;
            _table = _context.Set<T>();
        }



        public async Task Add(T entity)
        {
           await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            entity.Statu = Models.Enums.Statu.Passive;
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }



        public async Task<T> GetByDefault(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetByDefaults(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<TResult>> GetFilter<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _table;

            if (join != null) query = join(query);

            if (expression != null) query = query.Where(expression);

            if (orderBy != null) return await orderBy(query).Select(selector).ToListAsync();

            return await query.Select(selector).ToListAsync();
        }

        public async Task Update(T entity)
        {
            entity.Statu = Models.Enums.Statu.Modified;
            entity.UpdateDate = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

using Madhuu_PMS.Infrastructure.IRepository;
using Madhuu_PMS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Madhuu_PMS.Infrastructure.Repository.Crud
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        private readonly  PMSDbContext _context;
        public CrudService(PMSDbContext context)
        {
            _context = context;
        }
        public int Delete(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return result.Entity.Id;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public int Insert(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public async Task<int> InsertAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public int Update(T entity)
        {
            _context.Set<T>().Update(entity).Property(x => x.Id);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity).Property(x => x.Id);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<int> DeleteAsync(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
        public async Task<T> GetAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }




        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).SingleOrDefaultAsync();
        }



    }
}
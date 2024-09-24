using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WedMVCDemo.Entities.Models;
using WedMVCDemo.Interfaces;
using WedMVCDemo.Models;

namespace WedMVCDemo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : MainModel
    {
        private MyDbContext _db;
        private DbSet<T> _dbSet;
        public GenericRepository(MyDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task<T> AddItemAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await GetByIdAsync(id);
            _dbSet.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, string[] incules = null)
        {
            IQueryable<T> query  = _dbSet;
            if(incules != null)
            {
                foreach (var incule in incules) { 
                    query = query.Include(incule).AsSplitQuery();
                }
            }

            if (expression != null) 
            {
                return await query.Where(expression).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> expression = null, string[] incules = null)
        {
            IQueryable<T> query = _dbSet;
            if (incules != null)
            {
                foreach (var incule in incules)
                {
                    query = query.Include(incule).AsSplitQuery();
                }
            }

            if (expression != null)
            {
                return await query.Where(expression).FirstOrDefaultAsync();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateItemAsync(T item)
        {
            _dbSet.Update(item);
           await  _db.SaveChangesAsync();
            return item;
        }
    }
}

using _1.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DALL.Repositories._GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly SanaDbContext _context;
        private readonly DbSet<T> dbSet;



        public GenericRepository(SanaDbContext sanaDbContext) 
        {
            this._context = sanaDbContext;
            this.dbSet = _context.Set<T>();
        }




        public async Task<bool> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }
    }
}

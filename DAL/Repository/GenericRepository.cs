using DAL.Context;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        } 
        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }  
        
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }  
        
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                //await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                
                return false;
            }
        }      

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {            
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _dbSet.Update(entity);              
                return true;
            }
            catch
            {
                          
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _dbSet.Remove(entity);               
                return true;
            }
            catch 
            {                            
               return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> include)
        {
            return await _dbSet.Include(include).ToListAsync();
        }
    }
}


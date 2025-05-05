using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class WorkersRepository : IWorkers
    {
        private readonly ApplicationContext _context;

        public WorkersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Workers entity)
        {
            try
            {
                await _context.Workers.AddAsync(entity);                
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
                var entity = await _context.Workers.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.Workers.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Workers>> GetAllAsync()
        {
            return await _context.Workers.ToListAsync();
        }

        public async Task<Workers> GetByIdAsync(int id)
        {
            return await _context.Workers.FindAsync(id);
        }

        public async Task<Workers> GetWorkersUserId (string id)
        {
           return await _context.Workers.FirstOrDefaultAsync(w => w.ApplicationUserId == id);
        }

        public async Task<bool> UpdateAsync(Workers entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.Workers.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

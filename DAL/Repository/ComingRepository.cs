using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ComingRepository : IComing
    {
        private readonly ApplicationContext _context;
        public ComingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Coming entity)
        {
            try
            {
                await _context.Comings.AddAsync(entity);
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
                var entity = await _context.Comings.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.Comings.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Coming>> GetAllAsync()
        {
            return await _context.Comings.ToListAsync();
        }

        public async Task<Coming> GetByIdAsync(int id)
        {
            return await _context.Comings.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Coming entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.Comings.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

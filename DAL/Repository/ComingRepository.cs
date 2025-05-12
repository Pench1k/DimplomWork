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
                    return false;
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
            return await _context.Comings.Include(c => c.User).ToListAsync();
        }

        public async Task<Coming?> GetByIdAsync(int id)
        {
            return await _context.Comings
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Coming>> GetByUserIdAsync(string userId)
        {
            return await _context.Comings
                .Where(c => c.UserId == userId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Coming entity)
        {
            try
            {
                var existing = await _context.Comings.FindAsync(entity.Id);
                if (existing == null) return false;

                _context.Entry(existing).CurrentValues.SetValues(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

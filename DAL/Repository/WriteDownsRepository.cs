using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    
    public class WriteDownsRepository : IWriteDowns
    {
        private readonly ApplicationContext _context;

        public WriteDownsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(WriteDowns entity)
        {
            try
            {
                await _context.WriteDowns.AddAsync(entity);
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
                var entity = await _context.WriteDowns.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.WriteDowns.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<WriteDowns>> GetAllAsync()
        {
            return await _context.WriteDowns.ToListAsync();
        }

        public async Task<WriteDowns> GetByIdAsync(int id)
        {
            return await _context.WriteDowns.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(WriteDowns entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.WriteDowns.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ComputerPassportRepository : IComputerPassport
    {
        private readonly ApplicationContext _context;

        public ComputerPassportRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ComputerPassport entity)
        {
            try
            {
                await _context.ComputerPassports.AddAsync(entity);
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
                var entity = await _context.ComputerPassports.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.ComputerPassports.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ComputerPassport>> GetAllAsync()
        {
            return await _context.ComputerPassports.ToListAsync();
        }

        public async Task<ComputerPassport> GetByIdAsync(int id)
        {
            return await _context.ComputerPassports.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(ComputerPassport entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.ComputerPassports.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> ExistInventoryNumber(string inventoryNumber)
        {
            var exists = await _context.ComputerPassports
                .AsNoTracking()
                .AnyAsync(c => c.InventoryNumber.Trim() == inventoryNumber.Trim());

            return exists;
        }
    }
}

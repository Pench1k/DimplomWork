using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Reporitory
{
    public class RepairComputerRepository : IRepairComputer
    {
        private readonly ApplicationContext _context;

        public RepairComputerRepository(ApplicationContext context)
        {
            _context = context; 
        }

        public async Task<bool> AddAsync(RepairComputer entity)
        {
            try
            {
                await _context.RepairComputers.AddAsync(entity);
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
                var entity = await _context.RepairComputers.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.RepairComputers.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<RepairComputer>> GetAllAsync()
        {
            return await _context.RepairComputers.ToListAsync();
        }

        public async Task<RepairComputer> GetByIdAsync(int? id)
        {
            return await _context.RepairComputers.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(RepairComputer entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.RepairComputers.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

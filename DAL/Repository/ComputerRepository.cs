using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ComputerRepository : IComputer
    {
        private readonly ApplicationContext _context;

        public ComputerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Computer entity)
        {
            try
            {
                await _context.Computers.AddAsync(entity);
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
                var entity = await _context.Computers.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.Computers.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Computer>> GetAllAsync()
        {
            return await _context.Computers.ToListAsync();
        }

        public async Task<Computer?> GetByIdAsync(int? id)
        {
            return await _context.Computers.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Computer entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.Computers.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<Computer?> GetByIdWithComponentsAsync(int id)
        {
            return await _context.Computers
                .Include(c => c.Processor)
                .Include(c => c.Motherboard)
                .Include(c => c.Ram)
                .Include(c => c.VideoCard)
                .Include(c => c.PowerUnit)
                .Include(c => c.MemoryDisk)
                .Include(c => c.Oc)
                .Include(c => c.Keyboard)
                .Include(c => c.Mouse)
                .Include(c => c.Screen)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Computer>> GetAllWithComponentsStatusPendingAsync()
        {
            return await _context.Computers
                .Where(c => c.ComputerStatus == ComputerStatus.PendingConfirmation)
                .Include(c => c.Processor)
                .Include(c => c.Motherboard)
                .Include(c => c.Ram)
                .Include(c => c.VideoCard)
                .Include(c => c.PowerUnit)
                .Include(c => c.MemoryDisk)
                .Include(c => c.Oc)
                .Include(c => c.Keyboard)
                .Include(c => c.Mouse)
                .Include(c => c.Screen)
                .ToListAsync();
        }

        public async Task<bool> ConfirmComputer(int id, int comingId)
        {
            var computers = await GetByIdAsync(id);

            if (computers != null)
            {
                computers.ComputerStatus = ComputerStatus.Confirmed;
                computers.ComingId = comingId;
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Computer>> GetAllWithComponentsStatusConfirmedAsync()
        {
            return await _context.Computers
                .Where(c => c.ComputerStatus == ComputerStatus.Confirmed)
                .Include(c => c.Processor)
                .Include(c => c.Motherboard)
                .Include(c => c.Ram)
                .Include(c => c.VideoCard)
                .Include(c => c.PowerUnit)
                .Include(c => c.MemoryDisk)
                .Include(c => c.Oc)
                .Include(c => c.Keyboard)
                .Include(c => c.Mouse)
                .Include(c => c.Screen)
                .ToListAsync();
        }
    }
}


using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

        public async Task<ComputerPassport> GetByIdAsync(int? id)
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

        public async Task<IEnumerable<ComputerPassport>> GetAllComputerPassportWithComputerWarehouse(int warehouseId)
        {
            return await _context.ComputerPassports.Where(cp => cp.WarehouseId == warehouseId).AsNoTracking()
                    .Include(cp => cp.User)                   
                    .Include(cp => cp.Computer) 
                        .ThenInclude(c => c.Processor) 
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Motherboard) 
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Ram) 
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Oc) 
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.MemoryDisk)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.PowerUnit)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.VideoCard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Mouse)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Keyboard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Screen)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Coming)
                    .ToListAsync();
        }

        public async Task<IEnumerable<ComputerPassport>> GetAllComputerPassportWithComputerRector()
        {
            return await _context.ComputerPassports.Where(cp => cp.WarehouseId != null && cp.computerPassportStatus == ComputerPassportStatus.ReadyForDistribution).AsNoTracking()
                    .Include(cp => cp.User)
                    .Include(cp => cp.Warehouse)
                    .Include(cp => cp.Computer)                 
                        .ThenInclude(c => c.Processor)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Motherboard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Ram)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Oc)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.MemoryDisk)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.PowerUnit)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.VideoCard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Mouse)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Keyboard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Screen)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Coming)
                    .ToListAsync();
        }

        public async Task<IEnumerable<ComputerPassport>> GetAllComputerPassportWithComputerMethodist(int departmentId)
        {
            return await _context.ComputerPassports.Where(cp => cp.Office.DepartmentId == departmentId && cp.computerPassportStatus == ComputerPassportStatus.Work).AsNoTracking() //???
                    .Include(cp => cp.User)
                    .Include(cp => cp.Office)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Processor)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Motherboard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Ram)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Oc)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.MemoryDisk)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.PowerUnit)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.VideoCard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Mouse)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Keyboard)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Screen)
                    .Include(cp => cp.Computer)
                        .ThenInclude(c => c.Coming)
                    .ToListAsync();
        }
    }
}

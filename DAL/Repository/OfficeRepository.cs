using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly ApplicationContext _context;

        public OfficeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Office entity)
        {
            try
            {
                await _context.Offices.AddAsync(entity);
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
                var entity = await _context.Offices.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.Offices.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ExistsAsync(int number, int body)
        {
            return await _context.Offices
           .AnyAsync(o => o.Number == number && o.Body == body);
        }

        public async Task<IEnumerable<Office>> GetAllAsync()
        {
            return await _context.Offices.ToListAsync();
        }

        public async Task<IEnumerable<Office>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Offices
            .Where(o => o.DepartmentId == departmentId)
            .Include(o => o.Department)
            .ToListAsync();
        }

        public async Task<Office> GetByIdAsync(int? id)
        {
            return await _context.Offices.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Office entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.Offices.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

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

        public async Task<Computer> GetByIdAsync(int id)
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
    }
}



using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class MovingThroughDivisionsRepository : IMovingThroughDivisions
    {
        private readonly ApplicationContext _context;

        public MovingThroughDivisionsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(MovingThroughDivisions entity)
        {
            try
            {
                await _context.MovingThroughDivisions.AddAsync(entity);
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
                var entity = await _context.MovingThroughDivisions.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.MovingThroughDivisions.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<MovingThroughDivisions>> GetAllAsync()
        {
            return await _context.MovingThroughDivisions.ToListAsync();
        }

        public async Task<MovingThroughDivisions> GetByIdAsync(int? id)
        {
            return await _context.MovingThroughDivisions.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(MovingThroughDivisions entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.MovingThroughDivisions.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

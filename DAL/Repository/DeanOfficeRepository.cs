using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class DeanOfficeRepository : IDeanOffice
    {
        private readonly ApplicationContext _context;
        public DeanOfficeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(DeanOffice entity)
        {
           await _context.DeanOffices.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.DeanOffices.FindAsync(id);
            if (entity != null)
            {
                _context.DeanOffices.Remove(entity);
            }
        }

        public async Task<DeanOffice>? Get(int id)
        {
            return await _context.DeanOffices.FindAsync(id);
        }

        public async Task<ICollection<DeanOffice>> GetAll()
        {
            return await _context.DeanOffices.ToListAsync();
        }

        public async Task Update(DeanOffice entity)
        {
            _context.DeanOffices.Update(entity);
        }
    }
}

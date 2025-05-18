using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ArrivalFromTheWarehouseRepository : IArrivalFromTheWarehouse
    {

        private readonly ApplicationContext _context;

        public ArrivalFromTheWarehouseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ArrivalFromTheWarehouse entity)
        {
            try
            {
                await _context.ArrivalFromTheWarehouses.AddAsync(entity);
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
                var entity = await _context.ArrivalFromTheWarehouses.FindAsync(id);
                if (entity == null)
                {
                    // Сущность не найдена
                    return false;
                }

                _context.ArrivalFromTheWarehouses.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ArrivalFromTheWarehouse>> GetAllAsync()
        {
            return await _context.ArrivalFromTheWarehouses.ToListAsync();
        }

        public async Task<ArrivalFromTheWarehouse> GetByIdAsync(int? id)
        {
            return await _context.ArrivalFromTheWarehouses.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(ArrivalFromTheWarehouse entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
                }
                _context.ArrivalFromTheWarehouses.Update(entity);
                return true;
            }
            catch
            {

                return false;
            }
        }


        public async Task<IEnumerable<ArrivalFromTheWarehouse>> ArrivalFromTheWarehouseAccepts(int warehouseId)
        {
            return await _context.ArrivalFromTheWarehouses.Where(aftw => aftw.WarehouseId == warehouseId && aftw.Status == StatusForArrival.WaiteWarehouse)
                .Include(aftw => aftw.Office)
                  .ThenInclude(of => of.Department)
                .Include(aftw => aftw.ComputerPassport)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ArrivalFromTheWarehouse>> ArrivalFromTheMetodistAccepts(int departmentId)
        {

            return await _context.ArrivalFromTheWarehouses.Where(aftw => aftw.Office.DepartmentId == departmentId && aftw.Status == StatusForArrival.WaiteMetodist)
               .Include(aftw => aftw.Office)
                 .ThenInclude(of => of.Department)
               .Include(aftw => aftw.ComputerPassport)
               .AsNoTracking().ToListAsync();
        }
    }
}

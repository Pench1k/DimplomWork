
using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class PowerUnitRepository : IPowerUnit
    {
        private readonly ApplicationContext _context;

        public PowerUnitRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(PowerUnit entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PowerUnit> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PowerUnit>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(PowerUnit entity)
        {
            throw new NotImplementedException();
        }
    }
}

using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class ArrivalFromTheWarehouseRepository : IArrivalFromTheWarehouse
    {

        private readonly ApplicationContext _context;

        public ArrivalFromTheWarehouseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(ArrivalFromTheWarehouse entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArrivalFromTheWarehouse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ArrivalFromTheWarehouse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ArrivalFromTheWarehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}

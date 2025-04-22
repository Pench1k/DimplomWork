using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Reporitory
{
    public class RepairComputerRepository : IRepairComputer
    {
        private readonly ApplicationContext _context;

        public RepairComputerRepository(ApplicationContext context)
        {
            _context = context; 
        }

        public Task Create(RepairComputer entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RepairComputer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RepairComputer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(RepairComputer entity)
        {
            throw new NotImplementedException();
        }
    }
}

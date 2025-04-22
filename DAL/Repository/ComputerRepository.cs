using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class ComputerRepository : IComputer
    {
        private readonly ApplicationContext _context;

        public ComputerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(Computer entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Computer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Computer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Computer entity)
        {
            throw new NotImplementedException();
        }
    }
}

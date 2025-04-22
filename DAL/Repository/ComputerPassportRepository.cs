using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class ComputerPassportRepository : IComputerPassport
    {
        private readonly ApplicationContext _context;

        public ComputerPassportRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(ComputerPassport entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ComputerPassport> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ComputerPassport>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ComputerPassport entity)
        {
            throw new NotImplementedException();
        }
    }
}

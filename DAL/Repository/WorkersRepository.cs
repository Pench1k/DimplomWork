using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class WorkersRepository : IWorkers
    {
        private readonly ApplicationContext _context;

        public WorkersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(Workers entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Workers> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Workers>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Workers entity)
        {
            throw new NotImplementedException();
        }
    }
}

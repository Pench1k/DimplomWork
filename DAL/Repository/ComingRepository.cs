using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class ComingRepository : IComing
    {
        private readonly ApplicationContext _context;
        public ComingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(Coming entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Coming> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Coming>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Coming entity)
        {
            throw new NotImplementedException();
        }
    }
}

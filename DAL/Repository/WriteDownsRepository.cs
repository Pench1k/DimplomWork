using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    
    public class WriteDownsRepository : IWriteDowns
    {
        private readonly ApplicationContext _context;

        public WriteDownsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(WriteDowns entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WriteDowns> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<WriteDowns>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(WriteDowns entity)
        {
            throw new NotImplementedException();
        }
    }
}

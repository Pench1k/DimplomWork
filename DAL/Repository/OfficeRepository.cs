using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class OfficeRepository : IOffice
    {
        private readonly ApplicationContext _context;

        public OfficeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Office> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Office>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Office entity)
        {
            throw new NotImplementedException();
        }
    }
}

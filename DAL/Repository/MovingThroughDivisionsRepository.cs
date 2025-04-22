

using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class MovingThroughDivisionsRepository : IMovingThroughDivisions
    {
        private readonly ApplicationContext _context;

        public MovingThroughDivisionsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(MovingThroughDivisions entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovingThroughDivisions> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MovingThroughDivisions>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(MovingThroughDivisions entity)
        {
            throw new NotImplementedException();
        }
    }
}

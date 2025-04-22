

using DAL.Context;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}

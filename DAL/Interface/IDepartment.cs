using DAL.Models;

namespace DAL.Interface
{
    public interface IDepartment : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllWithDeanOfficeAsync();
    }
}

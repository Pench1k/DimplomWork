using DAL.Models;

namespace DAL.Interface
{
    public interface IOfficeRepository : IRepository<Office>
    {
        Task<IEnumerable<Office>> GetByDepartmentAsync(int departmentId);
        Task<bool> ExistsAsync(int number, int body);
    }
}

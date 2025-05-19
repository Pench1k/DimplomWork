using DAL.Models;

namespace DAL.Interface
{
    public interface IRepairComputer : IRepository<RepairComputer>
    {
        Task<IEnumerable<RepairComputer>> RepairOnDepartment(int departmentId);
    }
}

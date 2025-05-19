using BLL.DTO;
using DAL.Models;

namespace BLL.Interface
{
    public interface IRepairComputerService
    {
        Task<bool> AddAsync(RepairComputerCreate entity, string id);
        Task<IEnumerable<RepairComputerOnDepartment>> RepairOnDepartment(int departmentId);
        Task<bool> AcceptRepair(int id);
    }
}

using DAL.Models;

namespace DAL.Interface
{
    public interface IComputerPassport
    {
        Task<IEnumerable<ComputerPassport>> GetAllAsync();
        Task<ComputerPassport> GetByIdAsync(int id);
        Task<bool> AddAsync(ComputerPassport entity);
        Task<bool> UpdateAsync(ComputerPassport entity);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ComputerPassport>> GetAllComputerPassportWithComputerWarehouse(int warehouseId);

        Task<bool> ExistInventoryNumber(string inventoryNumber);

        Task<IEnumerable<ComputerPassport>> GetAllComputerPassportWithComputerRector();
    }
}

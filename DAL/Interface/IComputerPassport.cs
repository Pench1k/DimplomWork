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

        Task<bool> ExistInventoryNumber(string inventoryNumber);
    }
}

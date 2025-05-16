using DAL.Models;

namespace DAL.Interface
{
    public interface IComputer
    {
        Task<IEnumerable<Computer>> GetAllAsync();
        Task<Computer?> GetByIdAsync(int id);
        Task<bool> AddAsync(Computer entity);
        Task<bool> UpdateAsync(Computer entity);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Computer>> GetAllWithComponentsStatusPendingAsync();

        Task<IEnumerable<Computer>> GetAllWithComponentsStatusConfirmedAsync();
        Task<Computer?> GetByIdWithComponentsAsync(int id);

        Task<bool> ConfirmComputer(int id, int comingId);
    }
}

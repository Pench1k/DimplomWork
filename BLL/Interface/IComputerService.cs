using BLL.DTO;
using DAL.Models;


namespace BLL.Interface
{
    public interface IComputerService
    {
        Task<bool> AddAsync(ComputerDTO entity);

        Task<IEnumerable<ComputerWithComponents>> GetAllWithComponentsStatusPendingAsync();

        Task<bool> DeleteAsync(int id);

        Task<bool> ConfirmComputer(int id, int comingId);

        Task<IEnumerable<ComputerWithComponents>> GetAllWithComponentsStatusConfirmedAsync();
    }
}

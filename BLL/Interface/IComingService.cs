using BLL.DTO;
using DAL.Models;


namespace BLL.Interface
{
    public interface IComingService : IService<ComingDTO>
    {
        Task<IEnumerable<ComingDTO>> GetAllWithUserAsync(string userId);
    }
}
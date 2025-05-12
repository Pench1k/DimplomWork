using DAL.Models;

namespace DAL.Interface
{
    public interface IComing : IRepository<Coming>
    {
        Task<IEnumerable<Coming>> GetByUserIdAsync(string userId);
    }
}

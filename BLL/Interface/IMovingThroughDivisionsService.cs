using BLL.DTO;

namespace BLL.Interface
{
    public interface IMovingThroughDivisionsService
    {
        Task<bool> AddAsync(MovingThroughDivisionsCreate entity, string id);
    }
}

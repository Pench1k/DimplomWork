using BLL.DTO;

namespace BLL.Interface
{
    public interface IWriteDownsService
    {
        Task<bool> AddAsync(WriteDownCreate entity, string id);
    }
}

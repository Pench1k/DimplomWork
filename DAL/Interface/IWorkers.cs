using DAL.Models;

namespace DAL.Interface
{
    public interface IWorkers : IRepository<Workers>
    {
        Task<Workers> GetWorkersUserId(string id);
    }
}

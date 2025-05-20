using DAL.Models;

namespace DAL.Interface
{
    public interface IWriteDowns : IRepository<WriteDowns>
    {
        Task<IEnumerable<WriteDowns>> WriteDownWarehouseAccepts(int warehouseId);
    }
}

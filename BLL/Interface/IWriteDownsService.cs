using BLL.DTO;

namespace BLL.Interface
{
    public interface IWriteDownsService
    {
        Task<bool> AddAsync(WriteDownCreate entity, string id);
        Task<IEnumerable<WriteDownWarehouseAccept>> WriteDownWareHouseAccepts(int warehouseId);

        Task<bool> AcceptWarehouse(int id, string workId);
    }
}

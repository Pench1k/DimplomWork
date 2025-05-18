using BLL.DTO;

namespace BLL.Interface
{
    public interface IArrivalFromTheWarehouseService
    {
        Task<bool> AddAsync(ArrivalFromTheWarehouseCreate entity);

        Task<IEnumerable<ArrivalFromTheWareHouseAccept>> ArrivalFromTheWareHouseAccepts(int warehouseId);
        Task<IEnumerable<ArrivalFromTheWareHouseAccept>> ArrivalFromTheMetodistAccepts(int departmentId);


        Task<bool> AcceptWarehouse(int id);
        Task<bool> RejectWarehouse(int id);

        Task<bool> AcceptMethodist(int id);
        Task<bool> RejectMethodist(int id);
    }
}

using DAL.Models;

namespace DAL.Interface
{
    public interface IArrivalFromTheWarehouse : IRepository<ArrivalFromTheWarehouse>
    {
        Task<IEnumerable<ArrivalFromTheWarehouse>> ArrivalFromTheWarehouseAccepts(int warehouseId);

        Task<IEnumerable<ArrivalFromTheWarehouse>> ArrivalFromTheMetodistAccepts(int departmentId);
    }
}

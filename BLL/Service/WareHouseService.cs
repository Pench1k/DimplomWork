using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IUnitOfWork _unitOfWork;


        public WareHouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(WarehouseDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var warehouse = new Warehouse()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.Warehouse.AddAsync(warehouse);
                if (result)
                {
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                await _unitOfWork.RollbackAsync();
                return false;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();


                var success = await _unitOfWork.Warehouse.DeleteAsync(id);
                if (!success)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IEnumerable<WarehouseDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Warehouse.GetAllAsync();

            var dtoList = entities.Select(d => new WarehouseDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<WarehouseDTO> GetByIdAsync(int id)
        {
            WarehouseDTO warehouseDTO = new();
            var warehouse = await _unitOfWork.Warehouse.GetByIdAsync(id);
            if (warehouse == null)
                return null;
            warehouseDTO = new()
            {
                Id = warehouse.Id,
                Name = warehouse.Name
            };
            return warehouseDTO;
        }

        public async Task<bool> UpdateAsync(WarehouseDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var warehouse = new Warehouse()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.Warehouse.UpdateAsync(warehouse);
                if (!success)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}

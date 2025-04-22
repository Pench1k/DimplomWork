
using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class PowerUnitService : IPowerUnitService
    {
        private readonly IUnitOfWork _unitOfWork;


        public PowerUnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(PowerUnitDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var powerUnit = new PowerUnit()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.PowerUnit.AddAsync(powerUnit);
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


                var success = await _unitOfWork.PowerUnit.DeleteAsync(id);
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

        public async Task<IEnumerable<PowerUnitDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.PowerUnit.GetAllAsync();

            var dtoList = entities.Select(d => new PowerUnitDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<PowerUnitDTO> GetByIdAsync(int id)
        {
            PowerUnitDTO powerUnitDTO = new();
            var powerUnit = await _unitOfWork.PowerUnit.GetByIdAsync(id);
            if (powerUnit == null)
                return null;
            powerUnitDTO = new()
            {
                Id = powerUnit.Id,
                Name = powerUnit.Name
            };
            return powerUnitDTO;
        }

        public async Task<bool> UpdateAsync(PowerUnitDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var powerUnit = new PowerUnit()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.PowerUnit.UpdateAsync(powerUnit);
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

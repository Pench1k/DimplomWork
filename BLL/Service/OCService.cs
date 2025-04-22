using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class OCService : IOCService
    {
        private readonly IUnitOfWork _unitOfWork;


        public OCService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(OCDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var oc = new OC()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.OC.AddAsync(oc);
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


                var success = await _unitOfWork.OC.DeleteAsync(id);
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

        public async Task<IEnumerable<OCDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.OC.GetAllAsync();

            var dtoList = entities.Select(d => new OCDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<OCDTO> GetByIdAsync(int id)
        {
            OCDTO ocDTO = new();
            var oc = await _unitOfWork.OC.GetByIdAsync(id);
            if (oc == null)
                return null;
            ocDTO = new()
            {
                Id = oc.Id,
                Name = oc.Name
            };
            return ocDTO;
        }

        public async Task<bool> UpdateAsync(OCDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var oc = new OC()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.OC.UpdateAsync(oc);
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

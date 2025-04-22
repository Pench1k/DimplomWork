using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class RAMService : IRamService
    {
        private readonly IUnitOfWork _unitOfWork;


        public RAMService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(RAMDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var ram = new RAM()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.RAM.AddAsync(ram);
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


                var success = await _unitOfWork.RAM.DeleteAsync(id);
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

        public async Task<IEnumerable<RAMDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.RAM.GetAllAsync();

            var dtoList = entities.Select(d => new RAMDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<RAMDTO> GetByIdAsync(int id)
        {
            RAMDTO ramDTO = new();
            var ram = await _unitOfWork.RAM.GetByIdAsync(id);
            if (ram == null)
                return null;
            ramDTO = new()
            {
                Id = ram.Id,
                Name = ram.Name
            };
            return ramDTO;
        }

        public async Task<bool> UpdateAsync(RAMDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var ram = new RAM()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.RAM.UpdateAsync(ram);
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

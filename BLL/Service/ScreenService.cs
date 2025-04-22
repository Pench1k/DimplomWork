

using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class ScreenService : IScreenService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ScreenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(ScreenDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var screen = new Screen()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.Screen.AddAsync(screen);
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


                var success = await _unitOfWork.Screen.DeleteAsync(id);
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

        public async Task<IEnumerable<ScreenDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Screen.GetAllAsync();

            var dtoList = entities.Select(d => new ScreenDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<ScreenDTO> GetByIdAsync(int id)
        {
            ScreenDTO screenDTO = new();
            var screen = await _unitOfWork.Screen.GetByIdAsync(id);
            if (screen == null)
                return null;
            screenDTO = new()
            {
                Id = screen.Id,
                Name = screen.Name
            };
            return screenDTO;
        }

        public async Task<bool> UpdateAsync(ScreenDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var screen = new Screen()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.Screen.UpdateAsync(screen);
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

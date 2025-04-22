

using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class MouseService : IMouseService
    {
        private readonly IUnitOfWork _unitOfWork;


        public MouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(MouseDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var mouse = new Mouse()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.Mouse.AddAsync(mouse);
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


                var success = await _unitOfWork.Mouse.DeleteAsync(id);
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

        public async Task<IEnumerable<MouseDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Mouse.GetAllAsync();

            var dtoList = entities.Select(d => new MouseDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<MouseDTO> GetByIdAsync(int id)
        {
            MouseDTO mouseDTO = new();
            var mouse = await _unitOfWork.Mouse.GetByIdAsync(id);
            if (mouse == null)
                return null;
            mouseDTO = new()
            {
                Id = mouse.Id,
                Name = mouse.Name
            };
            return mouseDTO;
        }

        public async Task<bool> UpdateAsync(MouseDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var mouse = new Mouse()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.Mouse.UpdateAsync(mouse);
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

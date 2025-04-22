

using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class KeyboardService : IKeyboardService
    {
        private readonly IUnitOfWork _unitOfWork;


        public KeyboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(KeyboardDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var keyboard = new Keyboard()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.Keyboard.AddAsync(keyboard);
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


                var success = await _unitOfWork.Keyboard.DeleteAsync(id);
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

        public async Task<IEnumerable<KeyboardDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Keyboard.GetAllAsync();

            var dtoList = entities.Select(d => new KeyboardDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<KeyboardDTO> GetByIdAsync(int id)
        {
            KeyboardDTO keyboardDTO = new();
            var keyboard = await _unitOfWork.Keyboard.GetByIdAsync(id);
            if (keyboard == null)
                return null;
            keyboardDTO = new()
            {
                Id = keyboard.Id,
                Name = keyboard.Name
            };
            return keyboardDTO;
        }

        public async Task<bool> UpdateAsync(KeyboardDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var keyboard = new Keyboard()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.Keyboard.UpdateAsync(keyboard);
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

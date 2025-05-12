using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class ComingService : IComingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(ComingDTO entity)
        {
            try
            {
                // Базовые проверки
                if (string.IsNullOrWhiteSpace(entity.UserId))
                    throw new ArgumentException("Требуется идентификатор пользователя");

                if (string.IsNullOrWhiteSpace(entity.Provider))
                    throw new ArgumentException("Поставщик не может быть пустым");

                if (string.IsNullOrWhiteSpace(entity.DocumentNumber))
                    throw new ArgumentException("Номер документа не может быть пустым");

                // Проверка даты
                var currentDate = DateOnly.FromDateTime(DateTime.Today);
                if (entity.DateOfComing > currentDate)
                    throw new ArgumentException("Дата прихода не может быть в будущем");

                if (entity.DateOfComing < currentDate.AddYears(-1))
                    throw new ArgumentException("Дата прихода не может быть старше одного года");

                var coming = new Coming()
                {
                    Provider = entity.Provider,
                    DateOfComing = entity.DateOfComing ?? currentDate,
                    DocumentNumber = entity.DocumentNumber,
                    UserId = entity.UserId
                };
                await _unitOfWork.BeginTransactionAsync();
                var results = await _unitOfWork.Coming.AddAsync(coming);
                if (results)
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


                var success = await _unitOfWork.Coming.DeleteAsync(id);
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


        public async Task<IEnumerable<ComingDTO>> GetAllWithUserAsync(string userId)
        {
            var comings = await _unitOfWork.Coming.GetByUserIdAsync(userId);

            return comings.Select(c => new ComingDTO
            {
                Id = c.Id,
                Provider = c.Provider,
                DateOfComing = c.DateOfComing,
                DocumentNumber = c.DocumentNumber,
                UserId = c.UserId,
                UserName = c.User?.UserName
            });
        }

        public Task<IEnumerable<ComingDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ComingDTO> GetByIdAsync(int id)
        {
            var coming = await _unitOfWork.Coming.GetByIdAsync(id);
            if (coming == null)
                throw new KeyNotFoundException("Приход не найден");
            return new ComingDTO
            {
                Id = coming.Id,
                Provider = coming.Provider,
                DateOfComing = coming.DateOfComing,
                DocumentNumber = coming.DocumentNumber,
                UserId = coming.UserId,
                UserName = coming.User?.UserName
            };
        }

        public async Task<bool> UpdateAsync(ComingDTO entity)
        {
            
            if (string.IsNullOrWhiteSpace(entity.Provider))
                throw new ArgumentException("Поставщик не может быть пустым");

            if (string.IsNullOrWhiteSpace(entity.DocumentNumber))
                throw new ArgumentException("Номер документа не может быть пустым");

            // Проверка даты
            var currentDate = DateOnly.FromDateTime(DateTime.Today);
            if (entity.DateOfComing > currentDate)
                throw new ArgumentException("Дата прихода не может быть в будущем");

            if (entity.DateOfComing < currentDate.AddYears(-1))
                throw new ArgumentException("Дата прихода не может быть старше одного года");

            var coming = new Coming()
            {
                Id = entity.Id,
                Provider = entity.Provider,
                DateOfComing = entity.DateOfComing ?? currentDate,
                DocumentNumber = entity.DocumentNumber,
                UserId = entity.UserId,
            };
            await _unitOfWork.BeginTransactionAsync();
            var results = await _unitOfWork.Coming.UpdateAsync(coming);
            if (!results)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}

using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using DAL.Repository;

namespace BLL.Service
{
    public class OfficeService : IOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfficeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(OfficeDTO officeDto)
        {
            if (await _unitOfWork.Office.ExistsAsync(officeDto.Number, officeDto.Body))
            {
                throw new InvalidOperationException("Офис с таким номером в данном корпусе уже существует");
            }

            var office = new Office
            {
                Number = officeDto.Number,
                Body = officeDto.Body,
                DepartmentId = officeDto.DepartmentId,
                NumberOfAvailableSeats = officeDto.NumberOfAvailableSeats
            };

            await _unitOfWork.BeginTransactionAsync();

            var results = await _unitOfWork.Office.AddAsync(office);
            if (results)
            {
                await _unitOfWork.CommitAsync();
                return true;
            }

            await _unitOfWork.RollbackAsync();
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();


                var success = await _unitOfWork.Office.DeleteAsync(id);
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

        public async Task<bool> ExistsAsync(int number, int body)
        {
            return await _unitOfWork.Office.ExistsAsync(number, body);
        }

        public Task<IEnumerable<OfficeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OfficeDTO>> GetByDepartmentAsync(int departmentId)
        {
            var offices = await _unitOfWork.Office.GetByDepartmentAsync(departmentId);
            return offices.Select(o => new OfficeDTO
            {
                Id = o.Id,
                Body = o.Body,
                DepartmentId = o.DepartmentId,
                NumberOfAvailableSeats = o.NumberOfAvailableSeats,
                Number = o.Number,
            });
        }

        public async Task<OfficeDTO> GetByIdAsync(int id)
        {
            var office = await _unitOfWork.Office.GetByIdAsync(id);
            return new OfficeDTO
            {
                Id = office.Id,
                Body = office.Body,
                DepartmentId = office.DepartmentId,
                Number = office.Number,
                NumberOfAvailableSeats = office.NumberOfAvailableSeats
            };
        }

        public async Task<bool> UpdateAsync(OfficeDTO entity)
        {
            var office = await _unitOfWork.Office.GetByIdAsync(entity.Id);
            if (office == null) return false;

            // Проверяем, не занят ли новый номер+корпус другим офисом
            if (office.Number != entity.Number || office.Body != entity.Body)
            {
                if (await _unitOfWork.Office.ExistsAsync(entity.Number, entity.Body))
                {
                    throw new InvalidOperationException("Офис с таким номером в данном корпусе уже существует");
                }
            }

            // Обновляем данные
            office.Number = entity.Number;
            office.Body = entity.Body;
            office.DepartmentId = entity.DepartmentId;
            office.NumberOfAvailableSeats = entity.NumberOfAvailableSeats;


            await _unitOfWork.BeginTransactionAsync();
            var results = await _unitOfWork.Office.UpdateAsync(office);
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

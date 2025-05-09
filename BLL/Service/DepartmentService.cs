using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using DAL.Repository;

namespace BLL.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(DepartmentDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var department = new Department()
                {
                    Name = entity.Name,
                    DeanOfficeId = entity.DeanOfficeId,
                };

                var result = await _unitOfWork.Department.AddAsync(department);
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


                var success = await _unitOfWork.Department.DeleteAsync(id);
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

        public async Task<IEnumerable<DepartmentDTO>> GetAllAsync()
        {
            var departments = await _unitOfWork.Department.GetAllWithDeanOfficeAsync();

            return departments.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name,
                DeanOfficeId = d.DeanOfficeId,
                DeanOfficeName = d.DeanOffice?.Name
            });
        }

        public async Task<DepartmentDTO> GetByIdAsync(int id)
        {
            var department = await _unitOfWork.Department.GetByIdAsync(id);

            if (department == null)
                return null;

            string deanOfficeName = null;
            if (department.DeanOfficeId.HasValue)
            {
                var deanOffice = await _unitOfWork.DeanOffice.GetByIdAsync(department.DeanOfficeId.Value);
                deanOfficeName = deanOffice?.Name;
            }

            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name,
                DeanOfficeId = department.DeanOfficeId,
                DeanOfficeName = deanOfficeName
            };
        }

        public async Task<bool> UpdateAsync(DepartmentDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var department = new Department()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DeanOfficeId = entity.DeanOfficeId,
                };

                var success = await _unitOfWork.Department.UpdateAsync(department);
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
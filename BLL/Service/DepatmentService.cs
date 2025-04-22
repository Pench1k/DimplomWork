using BLL.DTO;
using BLL.Interface;
using DAL.Interface;

namespace BLL.Service
{
    public class DepatmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepatmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> AddAsync(DepartmentDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(DepartmentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using DAL.Repository;


namespace BLL.Service
{
    public class DeanOfficeService : IDeanOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public DeanOfficeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<bool> AddAsync(DeanOfficeDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var deanOffice = new DeanOffice()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.DeanOffice.AddAsync(deanOffice);
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


                var success = await _unitOfWork.DeanOffice.DeleteAsync(id);
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

        public async Task<IEnumerable<DeanOfficeDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.DeanOffice.GetAllAsync();

            var dtoList = entities.Select(d => new DeanOfficeDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<DeanOfficeDTO> GetByIdAsync(int id)
        {
            DeanOfficeDTO deanOfficeDTO = new();
            var deanOffice = await _unitOfWork.DeanOffice.GetByIdAsync(id);
            if (deanOffice == null)
                return null;
            deanOfficeDTO = new()
            {
                Id = deanOffice.Id,
                Name = deanOffice.Name
            };
            return deanOfficeDTO;
        }

        public async Task<bool> UpdateAsync(DeanOfficeDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var deanOffice = new DeanOffice()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.DeanOffice.UpdateAsync(deanOffice);
                if(!success)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }  
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch {
                return false;
            }
           
        }
    }
}
using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class WriteDownsService : IWriteDownsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WriteDownsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(WriteDownCreate entity, string id)
        {
            var writeDown = new WriteDowns
            {
                ComputerPassportId = entity.ComputerPassportId,
                WarehouseId = entity.WarehouseId,
                Note = entity.Note,
                DateOfWriteDowns = DateOnly.FromDateTime(DateTime.Today),
                Status = StatusWrite.WaiteWarehouse,
                UserId = id,

            };
            
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isAdded = await _unitOfWork.WriteDowns.AddAsync(writeDown);

                if (!isAdded)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }
    }
}

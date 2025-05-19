using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class MovingThroughDivisionsService : IMovingThroughDivisionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovingThroughDivisionsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(MovingThroughDivisionsCreate entity, string id)
        {
            var arrivalFromTheWarehouseCreate = new MovingThroughDivisions
            {
                ComputerPassportId = entity.ComputerPassportId,
                OfficeOldId = entity.OfficeOldId,
                OfficeNewId = entity.OfficeNewId,
                Note = entity.Note,
                DateOfMovingThroughDivisions = DateOnly.FromDateTime(DateTime.Today),
                UserId = id,
                Status = StatusForMoving.Сompleted,

            };

            var officeOld = await _unitOfWork.Office.GetByIdAsync(entity.OfficeOldId);
            var officeNew = await _unitOfWork.Office.GetByIdAsync(entity.OfficeNewId);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(entity.ComputerPassportId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isAdded = await _unitOfWork.MovingThroughDivisions.AddAsync(arrivalFromTheWarehouseCreate);
                if (!isAdded)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }
                officeOld.NumberOfAvailableSeats += 1;
                officeNew.NumberOfAvailableSeats -= 1;
                computerPassport.OfficeId = officeNew.Id;

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }
    }
}

using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class ComputerPassportService : IComputerPassportService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public ComputerPassportService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }


        public async Task<bool> AddAsync(ComputerPassportCreateDTO entity)
        {

            var computer = await _unitOfWork.Computer.GetByIdAsync(entity.ComputerId);
            if (computer == null)
                return false;

            var coming = await _unitOfWork.Coming.GetByIdAsync(computer.ComingId);
            if (coming == null)
                return false;


            var user = await _userService.GetByIdAsync(coming.UserId);
            if (user == null)
                return false;

            if(coming.DateOfComing > entity.DateOfDebit) 
                return false;

            if (await _unitOfWork.Passport.ExistInventoryNumber(entity.InventoryNumber))
            {
                return false;
            }


            var computerPassport = new ComputerPassport()
            {
                InventoryNumber = entity.InventoryNumber,
                ComputerId = entity.ComputerId,
                DateOfDebit = entity.DateOfDebit,
                DateOfReceipt = coming.DateOfComing,
                UserId = coming.UserId,
                WarehouseId = user?.WarehouseId,
                computerPassportStatus = ComputerPassportStatus.ReadyForDistribution,
            };

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isAdded = await _unitOfWork.Passport.AddAsync(computerPassport);
                computer.ComputerStatus = ComputerStatus.HavePassport;

                if (!isAdded)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ComputerPassportDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ComputerPassportDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ComputerPassportDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

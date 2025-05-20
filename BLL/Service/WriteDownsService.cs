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
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(entity.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {

                var isAdded = await _unitOfWork.WriteDowns.AddAsync(writeDown);
                computerPassport.computerPassportStatus = ComputerPassportStatus.OnWriteOff;
                computer.ComputerStatus = ComputerStatus.OnWriteOff;

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

        public async Task<IEnumerable<WriteDownWarehouseAccept>> WriteDownWareHouseAccepts(int warehouseId)
        {
            var writeDownWarehouseAccept = await _unitOfWork.WriteDowns.WriteDownWarehouseAccepts(warehouseId);

            return writeDownWarehouseAccept.Select(aftw => new WriteDownWarehouseAccept
            {
                Id = aftw.Id,
                ComputerPassportId = aftw.ComputerPassport?.Id,
                InventoryNumber = aftw.ComputerPassport?.InventoryNumber,
                WarehouseId = aftw.WarehouseId,
                WarehouseName = aftw.Warehouse.Name,
                DateOfWriteDowns = aftw.DateOfWriteDowns,
                Note = aftw.Note,
            });
        }

        public async Task<bool> AcceptWarehouse(int id, string workId)
        {
            var writeDownAccept = await _unitOfWork.WriteDowns.GetByIdAsync(id);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(writeDownAccept.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);
            var office = await _unitOfWork.Office.GetByIdAsync(computerPassport.OfficeId);



            await _unitOfWork.BeginTransactionAsync();
            try
            {
                writeDownAccept.Status = StatusWrite.Received;
                office.NumberOfAvailableSeats += 1;
                computerPassport.OfficeId = null;
                computerPassport.WarehouseId = writeDownAccept.WarehouseId;
                computerPassport.UserId = workId;

                if (computerPassport.DateOfDebit > DateOnly.FromDateTime(DateTime.Now))
                {
                    computerPassport.computerPassportStatus = ComputerPassportStatus.ReadyForDistribution;
                    computer.ComputerStatus = ComputerStatus.HavePassport;
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
    }
}

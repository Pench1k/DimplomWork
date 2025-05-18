

using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using System.Diagnostics.Metrics;

namespace BLL.Service
{
    public class ArrivalFromTheWarehouseService : IArrivalFromTheWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArrivalFromTheWarehouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AcceptWarehouse(int id)
        {
            var arrivalAccept = await _unitOfWork.ArrivalFromTheWarehouse.GetByIdAsync(id);
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                arrivalAccept.Status = StatusForArrival.WaiteMetodist;
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }

        }

        public async Task<bool> AcceptMethodist(int id)
        {
            var arrivalAccept = await _unitOfWork.ArrivalFromTheWarehouse.GetByIdAsync(id);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(arrivalAccept.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);
    
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                arrivalAccept.Status = StatusForArrival.Сompleted;
                computerPassport.WarehouseId = null;
                computerPassport.OfficeId = arrivalAccept.OfficeId;
                computerPassport.UserId = arrivalAccept.UserId;
                computerPassport.computerPassportStatus = ComputerPassportStatus.Work;
                computer.ComputerStatus = ComputerStatus.Work;

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }

        }

        public async Task<bool> AddAsync(ArrivalFromTheWarehouseCreate entity)
        {
            var arrivalFromTheWarehouseCreate = new ArrivalFromTheWarehouse
            {
                ComputerPassportId = entity.ComputerPassportId,
                WarehouseId = entity.WarehouseId,
                OfficeId = entity.OfficeId,
                UserId = entity.ResponsibleUserId,
                Note = entity.Note,
                DateOfArrivalFromTheWarehouse = DateOnly.FromDateTime(DateTime.Today),
                Status = StatusForArrival.WaiteWarehouse,
            };
            
            var office = await _unitOfWork.Office.GetByIdAsync(entity.OfficeId);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(entity.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isAdded = await _unitOfWork.ArrivalFromTheWarehouse.AddAsync(arrivalFromTheWarehouseCreate);
                office.NumberOfAvailableSeats -= 1;
                computer.ComputerStatus = ComputerStatus.Arrival; 
                computerPassport.computerPassportStatus = ComputerPassportStatus.Arrival;

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

        public async Task<IEnumerable<ArrivalFromTheWareHouseAccept>> ArrivalFromTheMetodistAccepts(int departmentId)
        {
            var arrivalFromTheWareHouseAccept = await _unitOfWork.ArrivalFromTheWarehouse.ArrivalFromTheMetodistAccepts(departmentId);

            return arrivalFromTheWareHouseAccept.Select(aftw => new ArrivalFromTheWareHouseAccept
            {
                Id = aftw.Id,
                ComputerPassportId = aftw.ComputerPassport?.Id,
                InventoryNumber = aftw.ComputerPassport?.InventoryNumber,
                OfficeId = aftw.OfficeId,
                Number = aftw.Office?.Number,
                Body = aftw.Office?.Body,
                DepartmentName = aftw.Office?.Department?.Name
            });
        }

        public async Task<IEnumerable<ArrivalFromTheWareHouseAccept>> ArrivalFromTheWareHouseAccepts(int warehouseId)
        {
            var arrivalFromTheWareHouseAccept = await _unitOfWork.ArrivalFromTheWarehouse.ArrivalFromTheWarehouseAccepts(warehouseId);

            return arrivalFromTheWareHouseAccept.Select(aftw => new ArrivalFromTheWareHouseAccept
            { 
                Id = aftw.Id,
                ComputerPassportId = aftw.ComputerPassport?.Id,
                InventoryNumber = aftw.ComputerPassport?.InventoryNumber,
                OfficeId = aftw.OfficeId,
                Number = aftw.Office?.Number,
                Body = aftw.Office?.Body,
                DepartmentName = aftw.Office?.Department?.Name
            });
        }

        public async Task<bool> RejectWarehouse(int id)
        {
            var arrivalAccept = await _unitOfWork.ArrivalFromTheWarehouse.GetByIdAsync(id);
            var office = await _unitOfWork.Office.GetByIdAsync(arrivalAccept.OfficeId);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(arrivalAccept.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                arrivalAccept.Status = StatusForArrival.RejectWarehouse;
                office.NumberOfAvailableSeats += 1;
                computerPassport.computerPassportStatus = ComputerPassportStatus.ReadyForDistribution;
                computer.ComputerStatus = ComputerStatus.HavePassport;

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> RejectMethodist(int id)
        {
            var arrivalAccept = await _unitOfWork.ArrivalFromTheWarehouse.GetByIdAsync(id);
            var office = await _unitOfWork.Office.GetByIdAsync(arrivalAccept.OfficeId);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(arrivalAccept.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                arrivalAccept.Status = StatusForArrival.RejectMetodist;
                office.NumberOfAvailableSeats += 1;
                computerPassport.computerPassportStatus = ComputerPassportStatus.ReadyForDistribution;
                computer.ComputerStatus = ComputerStatus.HavePassport;

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

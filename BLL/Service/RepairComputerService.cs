using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class RepairComputerService : IRepairComputerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepairComputerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(RepairComputerCreate entity, string id)
        {
            var repairComputerCreate = new RepairComputer
            {
                ComputerPassportId = entity.ComputerPassportId,
                Note = entity.Note,
                ServiceCenter = entity.ServiceCentre,
                DateOfRepairComputer = DateOnly.FromDateTime(DateTime.Today),
                UserId = id,
                Status = StatusRepair.Open,

            };

            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(entity.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isAdded = await _unitOfWork.RepairComputer.AddAsync(repairComputerCreate);
                computerPassport.computerPassportStatus = ComputerPassportStatus.UnderRenovation;
                computer.ComputerStatus = ComputerStatus.UnderRenovation;

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

        public async Task<IEnumerable<RepairComputerOnDepartment>> RepairOnDepartment(int departmentId)
        {
            var repairComputer = await _unitOfWork.RepairComputer.RepairOnDepartment(departmentId);

            return repairComputer.Select(c => new RepairComputerOnDepartment
            {
                Id = c.Id,
                ComputerPassportId = c.ComputerPassportId,
                InventoryNumber = c.ComputerPassport?.InventoryNumber,
                ServiceCenter = c.ServiceCenter,
                Note = c.Note,
                Body = c.ComputerPassport?.Office?.Body,
                DateOfRepairComputer = c.DateOfRepairComputer,
                Status = c.Status,
            });
        }

        public async Task<bool> AcceptRepair(int id)
        {
            var acceptRepair = await _unitOfWork.RepairComputer.GetByIdAsync(id);
            var computerPassport = await _unitOfWork.Passport.GetByIdAsync(acceptRepair.ComputerPassportId);
            var computer = await _unitOfWork.Computer.GetByIdAsync(computerPassport.ComputerId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                computerPassport.computerPassportStatus = ComputerPassportStatus.Work;
                computer.ComputerStatus = ComputerStatus.Work;
                acceptRepair.Status = StatusRepair.Close;

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

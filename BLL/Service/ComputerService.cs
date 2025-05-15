using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using System.Security.Cryptography;

namespace BLL.Service
{
    public class ComputerService : IComputerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ComputerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(ComputerDTO entity)
        {

            if (!entity.ProcessorId.HasValue)
                throw new ArgumentException("Не указан процессор");


            var computer = new Computer
            {
                ProcessorId = entity.ProcessorId,
                MotherboardId = entity.MotherboardId,
                RamId = entity.RamId,
                OcId = entity.OcId,
                MemoryDiskId = entity.MemoryDiskId,
                PowerUnitId = entity.PowerUnitId,
                VideoCardId = entity.VideoCardId,
                MouseId = entity.MouseId,
                KeyboardId = entity.KeyboardId,
                ScreenId = entity.ScreenId,
                ComputerStatus = ComputerStatus.PendingConfirmation
            };

            await _unitOfWork.BeginTransactionAsync();
            var results = await _unitOfWork.Computer.AddAsync(computer);
            if (results)
            {
                await _unitOfWork.CommitAsync();
                return true;
            }
            await _unitOfWork.RollbackAsync();
            return false;
        }

        public async Task<IEnumerable<ComputerWithComponents>> GetAllWithComponentsAsync()
        {
            var computer = await _unitOfWork.Computer.GetAllWithComponentsAsync();
            return computer.Select(c => new ComputerWithComponents
            {
                Id = c.Id,

                ProcessorId = c.ProcessorId,
                ProcessorName = c.Processor?.Name,

                MotherboardId = c.MotherboardId,
                MotherboardName = c.Motherboard?.Name,

                RamId = c.RamId,
                RamName = c.Ram?.Name,

                OcId = c.OcId,
                OcName = c.Oc?.Name,

                MemoryDiskId = c.MemoryDiskId,
                MemoryDiskName = c.MemoryDisk?.Name,

                PowerUnitId = c.PowerUnitId,
                PowerUnitName = c.PowerUnit?.Name,

                VideoCardId = c.VideoCardId,
                VideoCardName = c.VideoCard?.Name,

                MouseId = c.MouseId,
                MouseName = c.Mouse?.Name,

                KeyboardId = c.KeyboardId,
                KeyboardName = c.Keyboard?.Name,

                ScreenId = c.ScreenId,
                ScreenName = c.Screen?.Name,

                ComputerStatus = c.ComputerStatus,
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();


                var success = await _unitOfWork.Computer.DeleteAsync(id);
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

        public async Task<bool> ConfirmComputer(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();


                var success = await _unitOfWork.Computer.ConfirmComputer(id);
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

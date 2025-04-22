using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class MemoryDiskService : IMemoryDiskService
    {
        private readonly IUnitOfWork _unitOfWork;


        public MemoryDiskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(MemoryDiskDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var memoryDisk = new MemoryDisk()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.MemoryDisk.AddAsync(memoryDisk);
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


                var success = await _unitOfWork.MemoryDisk.DeleteAsync(id);
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

        public async Task<IEnumerable<MemoryDiskDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.MemoryDisk.GetAllAsync();

            var dtoList = entities.Select(d => new MemoryDiskDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<MemoryDiskDTO> GetByIdAsync(int id)
        {
            MemoryDiskDTO memoryDiskDTO = new();
            var oc = await _unitOfWork.MemoryDisk.GetByIdAsync(id);
            if (oc == null)
                return null;
            memoryDiskDTO = new()
            {
                Id = oc.Id,
                Name = oc.Name
            };
            return memoryDiskDTO;
        }

        public async Task<bool> UpdateAsync(MemoryDiskDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var memoryDisk = new MemoryDisk()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.MemoryDisk.UpdateAsync(memoryDisk);
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

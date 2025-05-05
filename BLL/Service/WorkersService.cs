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
    //public class WorkersService : IWorkersService
    //{
    //    private readonly IUnitOfWork _unitOfWork;


    //    public WorkersService(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;

    //    }

    //    public async Task<bool> AddAsync(WorkersDTO entity)
    //    {
    //        try
    //        {
    //            // Начинаем транзакцию
    //            await _unitOfWork.BeginTransactionAsync();

    //            var workers = new Workers()
    //            {
    //                ApplicationUserId = entity.ApplicationUserId,
    //                DepartmentId = entity.DepartmentId,
    //                WarehouseId = entity.WarehouseId
    //            };

    //            var result = await _unitOfWork.Workers.AddAsync(workers);
    //            if (result)
    //            {
    //                await _unitOfWork.CommitAsync();
    //                return true;
    //            }

    //            await _unitOfWork.RollbackAsync();
    //            return false;
    //        }
    //        catch
    //        {
    //            await _unitOfWork.RollbackAsync();
    //            return false;
    //        }
    //    }

    //    public async Task<bool> DeleteAsync(int id)
    //    {
    //        try
    //        {
    //            await _unitOfWork.BeginTransactionAsync();


    //            var success = await _unitOfWork.Workers.DeleteAsync(id);
    //            if (!success)
    //            {
    //                await _unitOfWork.RollbackAsync();
    //                return false;
    //            }

    //            await _unitOfWork.CommitAsync();
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    public async Task<IEnumerable<WorkersDTO>> GetAllAsync()
    //    {
    //        var entities = await _unitOfWork.Workers.GetAllAsync();

    //        var dtoList = entities.Select(d => new WorkersDTO
    //        {
    //            Id = d.Id,
    //            ApplicationUserId = d.ApplicationUserId,
    //            DepartmentId = d.DepartmentId,
    //            WarehouseId = d.WarehouseId
    //        });

    //        return dtoList;
    //    }

    //    public async Task<WorkersDTO> GetByIdAsync(int id)
    //    {            
    //        var workers = await _unitOfWork.Workers.GetByIdAsync(id);
    //        if (workers == null)
    //            return null;
    //        WorkersDTO workersDTO = new()
    //        {
    //            Id = workers.Id,
    //            ApplicationUserId = workers.ApplicationUserId,
    //            DepartmentId = workers.DepartmentId,
    //            WarehouseId = workers.WarehouseId
    //        };
    //        return workersDTO;
    //    }

    //    public async Task<bool> UpdateAsync(WorkersDTO entity)
    //    {
    //        try
    //        {
    //            await _unitOfWork.BeginTransactionAsync();

    //            var workers = new Workers()
    //            {
    //                Id = entity.Id,
    //                ApplicationUserId = entity.ApplicationUserId,
    //                DepartmentId = entity.DepartmentId,
    //                WarehouseId = entity.WarehouseId
    //            };

    //            var success = await _unitOfWork.Workers.UpdateAsync(workers);
    //            if (!success)
    //            {
    //                await _unitOfWork.RollbackAsync();
    //                return false;
    //            }
    //            await _unitOfWork.CommitAsync();
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //}
}

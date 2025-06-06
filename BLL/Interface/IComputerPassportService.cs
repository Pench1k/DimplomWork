﻿using BLL.DTO;

namespace BLL.Interface
{
    public interface IComputerPassportService
    {
        Task<IEnumerable<ComputerPassportDTO>> GetAllAsync();
        Task<ComputerPassportDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(ComputerPassportCreateDTO entity);
        Task<bool> UpdateAsync(ComputerPassportDTO entity);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ComputerPassportWithComputerWarehouse>> ComputerPassportWithComputerWarehouse(int warehouseId);
        Task<IEnumerable<ComputerPassportWithComputerRector>> ComputerPassportWithComputerRector();
        Task<IEnumerable<ComputerPassportWithComputerMethodist>> ComputerPassportWithComputerMethodist(int departmentId);
    }
}

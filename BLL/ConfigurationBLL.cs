﻿using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL.Interface;
using BLL.Service;
using DAL.Interface;
using DAL.Models;

namespace BLL
{
    public static class ConfigurationBLL
    {
        public static IServiceCollection AddBusinessLogical(this IServiceCollection service)
        {
            service.AddDynamicLinkLibary();
            
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IDepartmentService, DepartmentService>();
            service.AddScoped<IDeanOfficeService, DeanOfficeService>();
            service.AddScoped<IProcessorService, ProccesorService>();
            service.AddScoped<IMotherboardService, MotherboardService>();
            service.AddScoped<IRamService, RAMService>();
            service.AddScoped<IOCService, OCService>();
            service.AddScoped<IMemoryDiskService, MemoryDiskService>();
            service.AddScoped<IPowerUnitService, PowerUnitService>();
            service.AddScoped<IVideoCardService, VideoCardService>();
            service.AddScoped<IMouseService, MouseService>();
            service.AddScoped<IKeyboardService, KeyboardService>();
            service.AddScoped<IScreenService, ScreenService>();
            service.AddScoped<IWareHouseService, WareHouseService>();
            service.AddScoped<IComingService, ComingService>();
            service.AddScoped<IOfficeService, OfficeService>();
            service.AddScoped<IComputerService, ComputerService>();
            service.AddScoped<IComputerPassportService, ComputerPassportService>();

            service.AddScoped<IArrivalFromTheWarehouseService, ArrivalFromTheWarehouseService>();
            service.AddScoped<IMovingThroughDivisionsService, MovingThroughDivisionsService>();
            service.AddScoped<IRepairComputerService, RepairComputerService>();
            service.AddScoped<IWriteDownsService, WriteDownsService>();

            return service;
        }
    }
}

using DAL.Context;
using DAL.Interface;
using DAL.Models;
using DAL.Reporitory;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class ConfigurationDAL
    {
        public static IServiceCollection AddDynamicLinkLibary (this IServiceCollection service)
        {
          


            service.AddScoped<IArrivalFromTheWarehouse, ArrivalFromTheWarehouseRepository>();
            service.AddScoped<IComing, ComingRepository>();
            service.AddScoped<IComputer, ComputerRepository>();
            service.AddScoped<IComputerPassport, ComputerPassportRepository>();          
            service.AddScoped<IDepartment, DepartmentRepository>();
                    
            service.AddScoped<IMovingThroughDivisions, MovingThroughDivisionsRepository>();          
            service.AddScoped<IOffice, OfficeRepository>();                                  
            service.AddScoped<IRepairComputer, RepairComputerRepository>();
                        
            
            //service.AddScoped<IWorkers, WorkersRepository>();
            service.AddScoped<IWriteDowns, WriteDownsRepository>();


            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            
            return service;
        }
    }
}

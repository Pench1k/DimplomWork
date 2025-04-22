using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        IArrivalFromTheWarehouse ArrivalFromTheWarehouse { get; }
        IComing Coming { get; }
        IComputer Computer { get; }
        IComputerPassport Passport { get; }
        IGenericRepository<DeanOffice> DeanOffice { get; }
        IDepartment Department { get; }
        IGenericRepository<Keyboard> Keyboard { get; }
        IGenericRepository<MemoryDisk> MemoryDisk { get; }
        IGenericRepository<Motherboard> Motherboard { get; }
        IGenericRepository<Mouse> Mouse { get; }
        IMovingThroughDivisions MovingThroughDivisions { get;}
        IGenericRepository<OC> OC { get; }
        IOffice Office { get; }
        IGenericRepository<PowerUnit> PowerUnit { get; }
        IGenericRepository<Processor> Processor { get; }
        IGenericRepository<RAM> RAM { get; }
        IRepairComputer RepairComputer { get; }
        IGenericRepository<Screen> Screen { get; }
        IGenericRepository<VideoСard> VideoCard { get; }
        IGenericRepository<Warehouse> Warehouse { get; }
        IWorkers Workers { get; }   
        IWriteDowns WriteDowns { get; }


        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();


    }
}

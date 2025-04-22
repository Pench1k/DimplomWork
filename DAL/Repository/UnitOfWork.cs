

using DAL.Context;
using DAL.Interface;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IDbContextTransaction _currentTransaction;


        public IArrivalFromTheWarehouse ArrivalFromTheWarehouse { get; }
        public IComing Coming { get; }
        public IComputer Computer { get; }
        public IComputerPassport Passport { get; }
        public IGenericRepository<DeanOffice> DeanOffice { get; }
        public IDepartment Department { get; }
        public IGenericRepository<Keyboard> Keyboard { get; }
        public IGenericRepository<MemoryDisk> MemoryDisk { get; }
        public IGenericRepository<Motherboard> Motherboard { get; }
        public IGenericRepository<Mouse> Mouse { get; }
        public IMovingThroughDivisions MovingThroughDivisions { get; }
        public IGenericRepository<OC> OC { get; }
        public IOffice Office { get; }
        public IGenericRepository<PowerUnit> PowerUnit { get; }
        public IGenericRepository<Processor> Processor { get; }
        public IGenericRepository<RAM> RAM { get; }
        public IRepairComputer RepairComputer { get; }
        public IGenericRepository<Screen> Screen { get; }
        public IGenericRepository<VideoСard> VideoCard { get; }
        public IGenericRepository<Warehouse> Warehouse { get; }
        public IWorkers Workers { get; }
        public IWriteDowns WriteDowns { get; }

        public UnitOfWork(ApplicationContext context, 
            IArrivalFromTheWarehouse ArrivalFromTheWarehouse, 
            IComing Coming, 
            IComputer Computer, 
            IComputerPassport Passport,
            IGenericRepository<DeanOffice> DeanOffice,
            IDepartment Department,
            IGenericRepository<Keyboard> Keyboard,
            IGenericRepository<MemoryDisk> MemoryDisk,
            IGenericRepository<Motherboard> Motherboard,
            IGenericRepository<Mouse> Mouse,
            IMovingThroughDivisions MovingThroughDivisions,
            IGenericRepository<OC> OC,
            IOffice Office,
            IGenericRepository<PowerUnit> PowerUnit,
            IGenericRepository<Processor> Processor,
            IGenericRepository<RAM> RAM,
            IRepairComputer RepairComputer,
            IGenericRepository<Screen> Screen,
            IGenericRepository<VideoСard> VideoCard,
            IGenericRepository<Warehouse> Warehouse,
            IWorkers Workers,
            IWriteDowns WriteDowns)
        {
            _context = context;
            this.ArrivalFromTheWarehouse = ArrivalFromTheWarehouse;
            this.Coming = Coming;
            this.Computer = Computer;
            this.Passport = Passport;
            this.DeanOffice = DeanOffice;
            this.Department = Department;
            this.Keyboard = Keyboard;
            this.MemoryDisk = MemoryDisk;
            this.Motherboard = Motherboard;
            this.Mouse = Mouse;
            this.MovingThroughDivisions = MovingThroughDivisions;
            this.OC = OC;
            this.Office = Office;
            this.PowerUnit = PowerUnit;
            this.Processor = Processor;
            this.RAM = RAM;
            this.RepairComputer = RepairComputer;
            this.Screen = Screen;            
            this.VideoCard = VideoCard;
            this.Warehouse = Warehouse;
            this.Workers = Workers;
            this.WriteDowns = WriteDowns;
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                
                await _context.SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                
                await _currentTransaction.RollbackAsync();
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _currentTransaction?.Dispose();
        }
    }
}

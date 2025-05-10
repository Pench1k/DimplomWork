using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public ApplicationContext()
        {

        }

        public DbSet<ArrivalFromTheWarehouse> ArrivalFromTheWarehouses { get; set; }
        public DbSet<Coming> Comings { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerPassport> ComputerPassports { get; set; }
        public DbSet<DeanOffice> DeanOffices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<MemoryDisk> MemoryDisks { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Mouse> Mouses { get; set; }
        public DbSet<MovingThroughDivisions> MovingThroughDivisions { get; set; }
        public DbSet<OC> Ocs { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<PowerUnit> PowerUnits { get; set; }
        public DbSet<Processor> Processor { get; set; }
        public DbSet<RAM> Rams { get; set; }
        public DbSet<RepairComputer> RepairComputers { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<VideoСard> VideoCards { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WriteDowns> WriteDowns { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=ComputerAccounting;Database=ComputerAccounting;Trusted_Connection=True;");
        //}

        private IDbContextTransaction _currentTransaction;


        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
                return;

            _currentTransaction = await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync(); // гарантируем сохранение
                await _currentTransaction?.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                try
                {
                    await _currentTransaction?.RollbackAsync();
                }
                finally
                {
                    if (_currentTransaction != null)
                    {
                        await _currentTransaction.DisposeAsync();
                        _currentTransaction = null;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new()
            {
                new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "Ответственный за склад",
                    NormalizedName = "ОТВЕТСТВЕННЫЙ ЗА СКЛАД"
                },
                new IdentityRole()
                {
                    Name = "Методист",
                    NormalizedName = "МЕТОДИСТ"
                },
                new IdentityRole()
                {
                    Name = "Инженер коммуниционного  центра",
                    NormalizedName = "ИНЖЕНЕР КОММУНИЦИОННОГО ЦЕНТРА"
                },
                new IdentityRole()
                {
                    Name = "Проректор",
                    NormalizedName = "ПРОРЕКТОР"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);


            modelBuilder.Entity<Department>()
                .HasOne(d => d.DeanOffice)
                .WithMany(d => d.Departments)
                .HasForeignKey(d => d.DeanOfficeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Coming>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comings)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

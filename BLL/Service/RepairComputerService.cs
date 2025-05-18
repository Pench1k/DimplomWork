using BLL.Interface;
using DAL.Interface;


namespace BLL.Service
{
    public class RepairComputerService : IRepairComputerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepairComputerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

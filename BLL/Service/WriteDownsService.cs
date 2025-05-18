using BLL.Interface;
using DAL.Interface;

namespace BLL.Service
{
    public class WriteDownsService : IWriteDownsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WriteDownsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}



using BLL.Interface;
using DAL.Interface;

namespace BLL.Service
{
    public class MovingThroughDivisionsService : IMovingThroughDivisionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovingThroughDivisionsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

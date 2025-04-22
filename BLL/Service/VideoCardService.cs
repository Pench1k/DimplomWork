using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    public class VideoCardService : IVideoCardService
    {
        private readonly IUnitOfWork _unitOfWork;


        public VideoCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(VideoСardDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var videoСard = new VideoСard()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.VideoCard.AddAsync(videoСard);
                if (result)
                {
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                await _unitOfWork.RollbackAsync();
                return false;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();


                var success = await _unitOfWork.VideoCard.DeleteAsync(id);
                if (!success)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IEnumerable<VideoСardDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.VideoCard.GetAllAsync();

            var dtoList = entities.Select(d => new VideoСardDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<VideoСardDTO> GetByIdAsync(int id)
        {
            VideoСardDTO videoCardDTO = new();
            var videoСard = await _unitOfWork.VideoCard.GetByIdAsync(id);
            if (videoСard == null)
                return null;
            videoCardDTO = new()
            {
                Id = videoСard.Id,
                Name = videoСard.Name
            };
            return videoCardDTO;
        }

        public async Task<bool> UpdateAsync(VideoСardDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var videoСard = new VideoСard()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.VideoCard.UpdateAsync(videoСard);
                if (!success)
                {
                    await _unitOfWork.RollbackAsync();
                    return false;
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}

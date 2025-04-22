using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using DAL.Models;

namespace BLL.Service
{
    class ProccesorService : IProcessorService
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProccesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> AddAsync(ProcessorDTO entity)
        {
            try
            {
                // Начинаем транзакцию
                await _unitOfWork.BeginTransactionAsync();

                var processor = new Processor()
                {
                    Name = entity.Name,
                };

                var result = await _unitOfWork.Processor.AddAsync(processor);
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


                var success = await _unitOfWork.Processor.DeleteAsync(id);
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

        public async Task<IEnumerable<ProcessorDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Processor.GetAllAsync();

            var dtoList = entities.Select(d => new ProcessorDTO
            {
                Id = d.Id,
                Name = d.Name
            });

            return dtoList;
        }

        public async Task<ProcessorDTO> GetByIdAsync(int id)
        {
            ProcessorDTO processorDTO = new();
            var processor = await _unitOfWork.Processor.GetByIdAsync(id);
            if (processor == null)
                return null;
            processorDTO = new()
            {
                Id = processor.Id,
                Name = processor.Name
            };
            return processorDTO;
        }

        public async Task<bool> UpdateAsync(ProcessorDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var processor = new Processor()
                {
                    Name = entity.Name,
                    Id = entity.Id
                };

                var success = await _unitOfWork.Processor.UpdateAsync(processor);
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

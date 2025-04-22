using BLL.DTO;
using BLL.Interface;

using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly IProcessorService _processorService;

        public ProcessorController(IProcessorService processorService)
        {
            _processorService = processorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProcessorCreate processorCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                ProcessorDTO processorDto = new() { Name = processorCreate.Name };
                var result = await _processorService.AddAsync(processorDto);
                if (!result)
                    return BadRequest("Не удалось добавить запись.");
                return Ok("Запись добавлена");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Произошла ошибка при обработке запроса.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _processorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _processorService.GetByIdAsync(id);
            if (result == null)  
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _processorService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProcessorCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new ProcessorDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _processorService.UpdateAsync(dto);
                if (!result)
                    return BadRequest("Не удалось обновить запись.");

                return Ok("Запись обновлена");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ошибка при обновлении записи.");
            }
        }
    }
}

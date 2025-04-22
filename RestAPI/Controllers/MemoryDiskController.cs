using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryDiskController : Controller
    {
        private readonly IMemoryDiskService _memoryDiskService;
        public MemoryDiskController(IMemoryDiskService memoryDiskService)
        {
            _memoryDiskService = memoryDiskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemoryDiskCreate memoryDiskCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var memoryDiskDTO = new MemoryDiskDTO()
                {
                    Name = memoryDiskCreate.Name,
                };

                var result = await _memoryDiskService.AddAsync(memoryDiskDTO);
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
            var result = await _memoryDiskService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _memoryDiskService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _memoryDiskService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MemoryDiskCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new MemoryDiskDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _memoryDiskService.UpdateAsync(dto);
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

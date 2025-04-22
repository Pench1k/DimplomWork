using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : Controller
    {
        private readonly IRamService _ramService;
        public RamController(IRamService ramService)
        {
            _ramService = ramService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RamCreate ramCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var ramDTO = new RAMDTO()
                {
                    Name = ramCreate.Name,
                };

                var result = await _ramService.AddAsync(ramDTO);
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
            var result = await _ramService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ramService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ramService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RamCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new RAMDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _ramService.UpdateAsync(dto);
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

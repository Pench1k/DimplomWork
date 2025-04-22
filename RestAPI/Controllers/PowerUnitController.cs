using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerUnitController : Controller
    {
        private readonly IPowerUnitService _powerUnitService;

        public PowerUnitController(IPowerUnitService powerUnitService)
        {
            _powerUnitService = powerUnitService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PowerUnitCreate powerUnitCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                PowerUnitDTO powerUnitDto = new() { Name = powerUnitCreate.Name };
                var result = await _powerUnitService.AddAsync(powerUnitDto);
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
            var result = await _powerUnitService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _powerUnitService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _powerUnitService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PowerUnitCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new PowerUnitDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _powerUnitService.UpdateAsync(dto);
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

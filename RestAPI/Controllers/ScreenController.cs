using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : Controller
    {
        private readonly IScreenService _screenService;

        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ScreenCreate screenCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                ScreenDTO screenDto = new() { Name = screenCreate.Name };
                var result = await _screenService.AddAsync(screenDto);
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
            var result = await _screenService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _screenService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _screenService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ScreenCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new ScreenDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _screenService.UpdateAsync(dto);
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

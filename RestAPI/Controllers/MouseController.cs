using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouseController : Controller
    {
        private readonly IMouseService _mouseService;

        public MouseController(IMouseService mouseService)
        {
            _mouseService = mouseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MouseCreate mouseCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                MouseDTO mouseDto = new() { Name = mouseCreate.Name };
                var result = await _mouseService.AddAsync(mouseDto);
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
            var result = await _mouseService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mouseService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mouseService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MouseCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new MouseDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _mouseService.UpdateAsync(dto);
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

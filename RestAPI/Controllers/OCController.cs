using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OCController : Controller
    {
        private readonly IOCService _ocService;

        public OCController(IOCService ocService)
        {
            _ocService = ocService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OCCreate ocCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                OCDTO ocDto = new() { Name = ocCreate.Name };
                var result = await _ocService.AddAsync(ocDto);
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
            var result = await _ocService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ocService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ocService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OCCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new OCDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _ocService.UpdateAsync(dto);
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

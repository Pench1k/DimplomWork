using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/deanoffice")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class DeanOfficeController : Controller
    {
        private readonly IDeanOfficeService _deanOfficeService;
        public DeanOfficeController(IDeanOfficeService deanOfficeService)
        {
            _deanOfficeService = deanOfficeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeanOfficeCreate deanOfficeCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var deanOfficeDTO = new DeanOfficeDTO()
                {
                    Name = deanOfficeCreate.Name,
                };

                var result = await _deanOfficeService.AddAsync(deanOfficeDTO);
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
            var result = await _deanOfficeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _deanOfficeService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound("Запись не найдена.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deanOfficeService.DeleteAsync(id);
            if (!result)
                return BadRequest("Не удалось удалить запись.");
            return Ok("Запись удалена");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DeanOfficeCreate updateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var dto = new DeanOfficeDTO
                {
                    Id = id,
                    Name = updateModel.Name
                };

                var result = await _deanOfficeService.UpdateAsync(dto);
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

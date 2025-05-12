using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComingController : ControllerBase
    {
        private readonly IComingService _comingService;
        public ComingController(IComingService comingService)
        {
            _comingService = comingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComingDTO comingDto)
        {
            try
            {
                // Получаем ID текущего пользователя
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Пользователь не аутентифицирован");
                }

                // Устанавливаем пользователя
                comingDto.UserId = userId;

                // Валидация данных
                if (string.IsNullOrWhiteSpace(comingDto.Provider))
                    return BadRequest("Поставщик не может быть пустым");

                if (string.IsNullOrWhiteSpace(comingDto.DocumentNumber))
                    return BadRequest("Номер документа не может быть пустым");

                // Устанавливаем текущую дату, если не указана
                if (comingDto.DateOfComing == null)
                {
                    comingDto.DateOfComing = DateOnly.FromDateTime(DateTime.Today);
                }

                // Проверка даты (не может быть в будущем)
                if (comingDto.DateOfComing > DateOnly.FromDateTime(DateTime.Today))
                {
                    return BadRequest("Дата прихода не может быть в будущем");
                }

                var result = await _comingService.AddAsync(comingDto);
                if (result)
                    return Ok("Приход зарегистрирован");

                return BadRequest("Не удалось создать приход");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var comings = await _comingService.GetAllWithUserAsync(userId);
                return Ok(comings);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _comingService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _comingService.DeleteAsync(id);
                if (result)
                    return NoContent();

                return BadRequest("Не удалось удалить приход");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Приход не найден");
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComingDTO comingDto)
        {
            try
            {

                if (id != comingDto.Id)
                    return BadRequest("ID в пути и теле запроса не совпадают");

                comingDto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var result = await _comingService.UpdateAsync(comingDto);
                if (result)
                    return NoContent();

                return BadRequest("Не удалось обновить приход");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Приход не найден");
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {   
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}

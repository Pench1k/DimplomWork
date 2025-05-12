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
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
              
                var departmentIdClaim = User.FindFirst("DepartmentId")?.Value;             
                if (string.IsNullOrEmpty(departmentIdClaim))
                {
                    return Forbid(); // 403 - нет доступа
                }           
                if (!int.TryParse(departmentIdClaim, out int departmentId)) { 
                                   
                    return BadRequest("Неверный формат идентификатора кафедры");
                }
                // Получаем офисы только для этой кафедры
                var offices = await _officeService.GetByDepartmentAsync(departmentId);

                return Ok(offices);
            }
            catch (Exception ex)
            {              
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OfficeDTO officeDto)
        {
            // 2. Валидация данных
            if (officeDto.Number <= 0)
                return BadRequest("Номер офиса должен быть положительным числом");

            if (officeDto.Body <= 0)
                return BadRequest("Номер корпуса должен быть положительным числом");

            if (officeDto.NumberOfAvailableSeats < 0)
                return BadRequest("Количество мест не может быть отрицательным");

            var departmentIdClaim = User.FindFirst("DepartmentId")?.Value;
            if (string.IsNullOrEmpty(departmentIdClaim))
            {
                return Forbid(); // 403 - нет доступа
            }
            if (!int.TryParse(departmentIdClaim, out int departmentId))
            {

                return BadRequest("Неверный формат идентификатора кафедры");
            }

            officeDto.DepartmentId = departmentId;

            var result = await _officeService.AddAsync(officeDto);

            if (result)
                return Ok("Кабинет зарегистрирован");

            return BadRequest("Не удалось создать кабинет");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var office = await _officeService.GetByIdAsync(id);

            if (office == null)
                return NotFound();

            return Ok(office);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _officeService.DeleteAsync(id);
                if (result)
                    return NoContent();

                return BadRequest("Не удалось удалить Кабинет");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Кабинет не найден");
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
        public async Task<IActionResult> Update(int id, [FromBody] OfficeDTO officeDto)
        {
            if (id != officeDto.Id)
            {
                return BadRequest("ID в URL не соответствует ID в теле запроса");
            }

            // 2. Валидация данных
            if (officeDto.Number <= 0)
                return BadRequest("Номер офиса должен быть положительным числом");

            if (officeDto.Body <= 0)
                return BadRequest("Номер корпуса должен быть положительным числом");

            if (officeDto.NumberOfAvailableSeats < 0)
                return BadRequest("Количество мест не может быть отрицательным");

            var departmentIdClaim = User.FindFirst("DepartmentId")?.Value;
            if (string.IsNullOrEmpty(departmentIdClaim))
            {
                return Forbid(); // 403 - нет доступа
            }

            if (!int.TryParse(departmentIdClaim, out int userDepartmentId))
            {
                return BadRequest("Неверный формат идентификатора кафедры");
            }

            // 4. Проверяем существование офиса
            var existingOffice = await _officeService.GetByIdAsync(id);
            if (existingOffice == null)
            {
                return NotFound("Кабинет не найден");
            }

            // 5. Проверяем принадлежность офиса к тому же отделу
            if (existingOffice.DepartmentId != userDepartmentId)
            {
                return Forbid("Вы можете редактировать только кабинеты своего отдела");
            }

            // 6. Проверка на уникальность (номер + корпус)
            if (existingOffice.Number != officeDto.Number || existingOffice.Body != officeDto.Body)
            {
                var exists = await _officeService.ExistsAsync(officeDto.Number, officeDto.Body);
                if (exists)
                {
                    return Conflict("Кабинет с таким номером и корпусом уже существует");
                }
            }

            // 7. Обновляем данные
            officeDto.DepartmentId = userDepartmentId; // Гарантируем, что отдел не изменится
            var result = await _officeService.UpdateAsync(officeDto);

            if (!result)
                return BadRequest("Не удалось обновить кабинет");

            return Ok("Кабинет успешно обновлен");
        }
    }
}

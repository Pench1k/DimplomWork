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
    public class ComputerPassportController : ControllerBase
    {
        private readonly IComputerPassportService _computerPassportService;
        public ComputerPassportController(IComputerPassportService computerPassportService)
        {
            _computerPassportService = computerPassportService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComputerPassportCreateDTO comingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _computerPassportService.AddAsync(comingDto);
            if (result)
                return Ok("Компьютер успешно добавлен");
            return BadRequest(new
            {
                error = true,
                message = "Не удалось создать паспорт. Проверьте данные."
            });
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWarehouse()
        {
            try
            {
                var warehouseIdClaim = User.FindFirst("WarehouseId")?.Value;
                if (string.IsNullOrEmpty(warehouseIdClaim))
                    return Forbid(); // 403 - нет доступа

                if (!int.TryParse(warehouseIdClaim, out int warehouseId))
                    return BadRequest("Неверный формат идентификатора склада");

                var result = await _computerPassportService.ComputerPassportWithComputerWarehouse(warehouseId);
                return Ok(result);
            }
            catch
            { 
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet("Rector")]
        public async Task<IActionResult> GetAllRector()
        {
            try
            {              
                var result = await _computerPassportService.ComputerPassportWithComputerRector();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet("Methodist")]
        public async Task<IActionResult> GetAllMethodist()
        {
            try
            {
                var departmentIdClaim = User.FindFirst("DepartmentId")?.Value;
                if (string.IsNullOrEmpty(departmentIdClaim))
                    return Forbid(); // 403 - нет доступа
                if (!int.TryParse(departmentIdClaim, out int departmentId))
                    return BadRequest("Неверный формат идентификатора подразделения");

                var result = await _computerPassportService.ComputerPassportWithComputerMethodist(departmentId);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}

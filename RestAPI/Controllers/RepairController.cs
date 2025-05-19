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
    public class RepairController : ControllerBase
    {
        private readonly IRepairComputerService _repairComputerService;

        public RepairController(IRepairComputerService repairComputerService)
        {
            _repairComputerService = repairComputerService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RepairComputerCreate repairComputerCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var results = await _repairComputerService.AddAsync(repairComputerCreate, userId);
            return results
             ? Ok(new { Success = true, Message = "Успешно перемещон!" })
             : BadRequest(new { Success = false, Message = "Отклонено" });
        }

        [HttpPut]
        public async Task<IActionResult> GetAllRepairOnDepartment()
        {
            var departmentIdClaim = User.FindFirst("DepartmentId")?.Value;
            if (string.IsNullOrEmpty(departmentIdClaim))
                return Forbid(); // 403 - нет доступа
            if (!int.TryParse(departmentIdClaim, out int departmentId))
                return BadRequest("Неверный формат идентификатора подразделения");

            var repaitOnDepartment = await _repairComputerService.RepairOnDepartment(departmentId);
            return Ok(repaitOnDepartment);
        }

        [HttpPut("AcceptRepair/{id}")]
        public async Task<IActionResult> AcceptRepair(int id)
        {
            var result = await _repairComputerService.AcceptRepair(id);

            if (result)
                return Ok(new { Success = true, Message = "Подтверждено" });
            return BadRequest(new { Success = false, Message = "Что-то пошло не так!!!" });
        }
    }
}

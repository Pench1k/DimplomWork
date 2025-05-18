using BLL.DTO;
using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalFromTheWarehouseController : ControllerBase
    {
        private readonly IArrivalFromTheWarehouseService _arrivalFromTheWarehouseService;
        public ArrivalFromTheWarehouseController(IArrivalFromTheWarehouseService arrivalFromTheWarehouseService)
        {
            _arrivalFromTheWarehouseService = arrivalFromTheWarehouseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArrivalFromTheWarehouseCreate arrivalFromTheWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var results = await _arrivalFromTheWarehouseService.AddAsync(arrivalFromTheWarehouse);
            return results
             ? Ok(new { Success = true, Message = "Успешно! Ожидает ответа от склада" })
             : BadRequest(new { Success = false, Message = "Отклонено" });
        }

        [HttpGet("AcceptWarehouse")]
        public async Task<IActionResult> GetAllFromWarehouseAccept()
        {
            var warehouseIdClaim = User.FindFirst("WarehouseId")?.Value;
            if (string.IsNullOrEmpty(warehouseIdClaim))
                return Forbid(); // 403 - нет доступа
            if(!int.TryParse(warehouseIdClaim, out int warehouseId))
                    return BadRequest("Неверный формат идентификатора склада");

            var arrivalFromTheWarehouseAccept = await _arrivalFromTheWarehouseService.ArrivalFromTheWareHouseAccepts(warehouseId);
            return Ok(arrivalFromTheWarehouseAccept);
        }

        [HttpGet("AcceptMethodist")]
        public async Task<IActionResult> GetAllFromMethodistAccept()
        {
            var departmentIdClaim = User.FindFirst("DepartmentId")?.Value;
            if (string.IsNullOrEmpty(departmentIdClaim))
                return Forbid(); // 403 - нет доступа
            if (!int.TryParse(departmentIdClaim, out int departmentId))
                return BadRequest("Неверный формат идентификатора подразделения");

            var arrivalFromTheWarehouseAccept = await _arrivalFromTheWarehouseService.ArrivalFromTheMetodistAccepts(departmentId);
            return Ok(arrivalFromTheWarehouseAccept);
        }

        [HttpPut("AcceptWarehouse/{id}")]
        public async Task<IActionResult> AcceptWarehouse(int id)
        {
            var result = await _arrivalFromTheWarehouseService.AcceptWarehouse(id);

            if (result)
                return Ok(new { Success = true, Message = "Подтверждено" });
            return BadRequest(new { Success = false, Message = "Что-то пошло не так!!!" });
        }

        [HttpPut("RejectWarehouse/{id}")]
        public async Task<IActionResult> RejectWarehouse(int id)
        {
            var result = await _arrivalFromTheWarehouseService.RejectWarehouse(id);

            if (result)
                return Ok(new { Success = false, Message = "Заявка отклонена" });
            return BadRequest(new { Success = false, Message = "Что-то пошло не так!!!" });
        }

        [HttpPut("AcceptMethodist/{id}")]
        public async Task<IActionResult> AcceptMethodist(int id)
        {
            var result = await _arrivalFromTheWarehouseService.AcceptMethodist(id);

            if (result)
                return Ok(new { Success = true, Message = "Подтверждено" });
            return BadRequest(new { Success = false, Message = "Что-то пошло не так!!!" });
        }

        [HttpPut("RejectMethodist/{id}")]
        public async Task<IActionResult> RejectMethodist(int id)
        {
            var result = await _arrivalFromTheWarehouseService.RejectMethodist(id);

            if (result)
                return Ok(new { Success = false, Message = "Заявка отклонена" });
            return BadRequest(new { Success = false, Message = "Что-то пошло не так!!!" });
        }

    }
}

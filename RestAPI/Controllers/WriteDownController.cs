using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteDownController : ControllerBase
    {
        private readonly IWriteDownsService _writeDownsService;

        public WriteDownController(IWriteDownsService writeDownsService)
        {
            _writeDownsService = writeDownsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WriteDownCreate writeDownCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var results = await _writeDownsService.AddAsync(writeDownCreate, userId);
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
            if (!int.TryParse(warehouseIdClaim, out int warehouseId))
                return BadRequest("Неверный формат идентификатора склада");

            var writeDownWareHouseAccepts = await _writeDownsService.WriteDownWareHouseAccepts(warehouseId);
            return Ok(writeDownWareHouseAccepts);
        }

        [HttpPut("AcceptWarehouse/{id}")]
        public async Task<IActionResult> AcceptWarehouse(int id)
        {
            string workId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _writeDownsService.AcceptWarehouse(id, workId);

            if (result)
                return Ok(new { Success = true, Message = "Подтверждено" });
            return BadRequest(new { Success = false, Message = "Что-то пошло не так!!!" });
        }

        
    }
}

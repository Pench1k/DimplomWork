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
    }
}

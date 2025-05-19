using BLL.DTO;
using BLL.Interface;
using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Azure.Core.HttpHeader;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovingThroughDivisionsController : ControllerBase
    {
        private readonly IMovingThroughDivisionsService _movingThroughDivisionsService;

        public MovingThroughDivisionsController(IMovingThroughDivisionsService movingThroughDivisions)
        {
            _movingThroughDivisionsService = movingThroughDivisions;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovingThroughDivisionsCreate movingThroughDivisions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var results = await _movingThroughDivisionsService.AddAsync(movingThroughDivisions, userId);
            return results
             ? Ok(new { Success = true, Message = "Успешно перемещон!" })
             : BadRequest(new { Success = false, Message = "Отклонено" });
        }
    }
}

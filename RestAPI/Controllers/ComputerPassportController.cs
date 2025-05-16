using BLL.DTO;
using BLL.Interface;
using BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _userService.Add(registerUserDto);
                if (!result)
                    return BadRequest("Не удалось зарегистрировать пользователя.");
                return Ok("Пользователь добавлен");

            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


    }
}

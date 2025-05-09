using BLL.DTO;
using BLL.Interface;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var token = await _userService.LoginAsync(loginUserDto);


            HttpContext.Response.Cookies.Append("tasty-cookies", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,              // Обязательно при SameSite=None
                SameSite = SameSiteMode.None,  // Разрешает межсайтовые запросы
                Expires = DateTime.UtcNow.AddHours(1)
            });
            return Ok(token);
        }

        [HttpGet("Users")]
        [Authorize(Roles = "admin")] // Добавляем аттрибут, чтобы только авторизованные пользователи могли вызвать этот метод
        public async Task<IActionResult> GetAllUsers()
        {
            var userAll = await _userService.GetAllAsync();


            return Ok(userAll);
        }

        [HttpGet("User")]
        [Authorize(Roles = "admin")] // Добавляем аттрибут, чтобы только авторизованные пользователи могли вызвать этот метод
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _userService.GetByUserNameAsync(userName);
            return Ok(user);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletUser(string userName)
        {
            var user = await _userService.GetByUserNameAsync(userName);
            await _userService.Delete(user);

            return Ok("Пользователь удален");
        }
    }
}

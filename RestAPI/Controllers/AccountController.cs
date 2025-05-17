using BLL.DTO;
using BLL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
                if (!await _userService.UserExistAsync(registerUserDto.UserName))
                {
                    return Conflict(new ApiResponse
                    {
                        Success = false,
                        Message = "Пользователь с таким логином уже существует"
                    });
                }
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userAll = await _userService.GetAllAsync();
            return Ok(userAll);
        }

        [HttpGet("User")]
        [Authorize(Roles = "admin")] 
        public async Task<IActionResult> GetUser(string userName)
        {
            var user = await _userService.GetByUserNameAsync(userName);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletUser(string id)
        {
            try
            {
                var currentUser = await _userService.GetUserAsync(User);
                if (currentUser == null)
                    return Unauthorized();

                var userToDelete = await _userService.GetByIdAsync(id);
                if(userToDelete == null)
                    return NotFound("Пользователь не найден");

                if (userToDelete.Id == currentUser.Id)
                    return BadRequest(new { Message = "Нельзя удалить самого себя" });

                var result = await _userService.Delete(userToDelete);

                if (!result.Succeeded)
                {
                    return BadRequest(string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                return Ok(new
                {
                    Success = true,
                    Message = "Пользователь успешно удален",
                    UserId = id
                });
            }
            catch 
            {
                return StatusCode(500, "Произошла ошибка при удалении");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<UserEditDTO?> GetUserByEdit(string id)
        {
            return await _userService.GetUserByEdit(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID в URL и теле запроса не совпадают");

            var result = await _userService.UpdateUserAsync(dto);

            if (result.Succeeded)
                return NoContent();

            // Специфичная обработка ошибок
            if (result.Errors.Any(e => e.Code == "UserNotFound"))
                return NotFound(new { message = result.Errors.First().Description });

            if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                return Conflict(new { message = result.Errors.First().Description });

            return BadRequest(result.Errors);
        }

        [HttpGet("ByDepartment/{departmentId}")]
        public async Task<IActionResult> GetUsersByDepartment(int departmentId)
        {
            try
            {
                var users = await _userService.GetByDepartmentId(departmentId);
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
    }
}

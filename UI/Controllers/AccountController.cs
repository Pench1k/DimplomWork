using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignInFromToken()
        {
            var token = HttpContext.Request.Cookies["tasty-cookies"];

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var claims = jwtToken.Claims.ToList();

                var userName = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.GivenName)?.Value;
                var userId = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value;

                
                if (userName != null)
                    claims.Add(new Claim(ClaimTypes.Name, userName));
                if (userId != null)             
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
                

                var roles = claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role)); // Добавляем роль как ClaimTypes.Role
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(12)
                });

                var riderectUrl = roles.FirstOrDefault() switch
                {
                    "admin" => Url.Action("Index", "Admin"),
                    "Методист" => Url.Action("Dashboard", "Methodist"),
                    "Проректор" => Url.Action("Dashboard", "Rector"),
                    "Инженер коммуникационного центра" => Url.Action("Dashboard", "Engineer"),
                    "Ответственный за склад" => Url.Action("Index", "ResponWarehouseOnly"),
                };
                return Json(new { riderectUrl });
            }
            return Ok();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
            HttpContext.Response.Cookies.Delete("tasty-cookies");
            return RedirectToAction("Login", "Account");
        }
    }
}

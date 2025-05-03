using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public AccountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }

        

    }
}

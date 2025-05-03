using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Filtres;
using UI.Models;

namespace UI.Controllers
{
    [JwtAuthorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }    
    }
}

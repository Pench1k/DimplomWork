using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }

        public IActionResult WarehouseEdit()
        {
            return View();
        }

        public IActionResult DeanOfficeEdit()
        {
            return View();
        }

        public IActionResult DepartmentEdit()
        {
            return View();
        }

    }
}

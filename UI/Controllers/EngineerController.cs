using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "Инженер коммуниционного  центра")]
    public class EngineerController : Controller
    {
        public IActionResult ComputerPassportAccept()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "Ответственный за склад")]
    public class ResponWarehouseOnlyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MouseEdit()
        {
            return View();
        }

        public IActionResult KeyboardEdit()
        {
            return View();
        }

        public IActionResult MemoryDiskEdit()
        {
            return View();
        }

        public IActionResult OCEdit()
        {
            return View();
        }

        public IActionResult ProcessorEdit()
        {
            return View();
        }

        public IActionResult RamEdit()
        {
            return View();
        }

        public IActionResult ScreenEdit()
        {
            return View();
        }

        public IActionResult VideoCardEdit()
        {
            return View();
        }

        public IActionResult PowerUnitEdit()
        {
            return View();
        }

        public IActionResult MotherboardEdit()
        {
            return View();
        }

        public IActionResult ComingEdit()
        {
            return View();
        }

        public IActionResult ConfiguratorPC()
        {
            return View();
        }

        public IActionResult ComputerEdit()
        {
            return View();
        }

        public IActionResult ComputerPassportSee()
        {
            return View();
        }

        public IActionResult ArrivalAcceptWarehouse()
        {
            return View();
        }

        public IActionResult ApplicationsForWriteOff()
        {
            return View();
        }
    }
}

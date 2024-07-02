using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult _NewAdminLayout()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult UILayoutPage()
        {
            return View();
        }
    }
}

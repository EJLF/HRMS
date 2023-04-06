using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

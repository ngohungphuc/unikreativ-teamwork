using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Unikreativ.Controllers.Unikreativ
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Partial/Dashboard/Index.cshtml");
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Unikreativ.Controllers.Unikreativ
{
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
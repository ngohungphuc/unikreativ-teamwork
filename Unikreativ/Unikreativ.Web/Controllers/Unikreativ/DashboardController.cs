using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Unikreativ.Web.Controllers.Unikreativ
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
using Microsoft.AspNetCore.Mvc;

namespace Unikreativ.Web.Controllers.SPA
{
    public class PartialController : Controller
    {
        public IActionResult App() => PartialView("~/Views/Partial/App.cshtml");

        #region Account

        public IActionResult Login() => PartialView("~/Views/Partial/Account/UserLogin.cshtml");

        #endregion Account

        #region Dashboard

        public IActionResult Dashboard() => PartialView("~/Views/Partial/Dashboard/Dashboard.cshtml");

        #endregion Dashboard

        #region Errors

        public IActionResult Error404() => PartialView("~/Views/Partial/Errors/Err404.cshtml");

        public IActionResult Error500() => PartialView("~/Views/Partial/Errors/Err500.cshtml");

        #endregion Errors
    }
}
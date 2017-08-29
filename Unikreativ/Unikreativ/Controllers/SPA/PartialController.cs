using Microsoft.AspNetCore.Mvc;

namespace Unikreativ.Controllers.SPA
{
    public class PartialController : Controller
    {
        public IActionResult App() => PartialView("~/Views/Partial/App.cshtml");

        #region Account

        public IActionResult Login() => PartialView("~/Views/Partial/Account/UserLogin.cshtml");

        #endregion Account

        #region Admin

        public IActionResult Admin() => PartialView("~/Views/Partial/Admin/Index.cshtml");

        public IActionResult UserManage() => PartialView("~/Views/Partial/Admin/User/UserManage.cshtml");

        public IActionResult ClientNew() => PartialView("~/Views/Partial/Admin/User/ClientNew.cshtml");

        public IActionResult ClientEdit() => PartialView("~/Views/Partial/Admin/User/ClientEdit.cshtml");

        public IActionResult NewMember() => PartialView("~/Views/Partial/Admin/User/NewMember.cshtml");

        public IActionResult EditMember() => PartialView("~/Views/Partial/Admin/User/EditMember.cshtml");

        #endregion Admin

        #region Event
        public IActionResult EventList() => PartialView("~/Views/Partial/Event/Event.cshtml");
        #endregion

        #region Project 
        public IActionResult Project() => PartialView("~/Views/Partial/Admin/Project/Project.cshtml");

        public IActionResult NewProject() => PartialView("~/Views/Partial/Admin/Project/NewProject.cshtml");

        public IActionResult ProjectList() => PartialView("~/Views/Partial/Admin/Project/ProjectList.cshtml");
        #endregion
        #region Errors

        public IActionResult Error404() => PartialView("~/Views/Partial/Errors/Err404.cshtml");

        public IActionResult Error500() => PartialView("~/Views/Partial/Errors/Err500.cshtml");

        #endregion Errors

        #region Template

        public IActionResult Header() => PartialView("~/Views/Partial/Template/Header.cshtml");

        public IActionResult Sidebar() => PartialView("~/Views/Partial/Template/Sidebar.cshtml");

        #endregion Template
    }
}
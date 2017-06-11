using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Unikreativ.Services.Interface;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class DataController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;

        public DataController(IUserServices userServices, UserManager<User> userManager)
        {
            _userManager = userManager;
            _userServices = userServices;
        }

        #region Get Info

        public IActionResult GetTeamMembers()
        {
            var members = _userServices.GetTeamMember();
            return Ok(members);
        }

        public IActionResult GetClients()
        {
            var clients = _userServices.GetClients();
            return Ok(clients);
        }

        #endregion Get Info
    }
}
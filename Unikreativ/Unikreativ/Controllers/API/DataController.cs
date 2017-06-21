using System.Threading.Tasks;
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

        public async Task<IActionResult> GetTeamMembers()
        {
            var members = await _userServices.GetTeamMembers();
            return Ok(members);
        }

        public async Task<IActionResult> GetClients()
        {
            var clients = await _userServices.GetClients();
            return Ok(clients);
        }

        #endregion Get Info
    }
}
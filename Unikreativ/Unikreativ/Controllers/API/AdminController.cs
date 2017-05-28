using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;

        public AdminController(IUserServices userServices, UserManager<User> userManager)
        {
            _userManager = userManager;
            _userServices = userServices;
        }

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
    }
}
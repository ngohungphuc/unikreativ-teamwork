using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IUserServices _userServices;

        public AdminController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult GetTeamMembers()
        {
            var users = _userServices.GetTeamMember();
            return Ok(users);
        }
    }
}
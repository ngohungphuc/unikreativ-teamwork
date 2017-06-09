using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Filter;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Authorize("Bearer")]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        #region Manage Account

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewClient([FromBody] Client clientDto)
        {
            var client = Mapper.Map<User>(clientDto);
            try
            {
                var result = await _userManager.CreateAsync(client, client.PasswordHash);
                if (!result.Succeeded) return Json(new { result = false, msg = "Something happend please try again" });
                await _userManager.AddToRoleAsync(client, "Client");
                return Json(new { msg = true, msg = "Create new Client success" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [ValidModel]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateClientInfo(Client clientDto)
        {
            var client = Mapper.Map<User>(clientDto);
            try
            {
                _unitOfWork.UserRepository.Edit(client);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion Manage Account
    }
}
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
        private readonly IUserServices _userServices;

        public AdminController(
            UserManager<User> userManager,
             IUserServices userServices)
        {
            _userManager = userManager;
            _userServices = userServices;
        }

        #region Manage Account

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewClient([FromBody] Client clientDto)
        {
            if (clientDto == null)
            {
                throw new ArgumentNullException(nameof(clientDto));
            }

            var client = Mapper.Map<User>(clientDto);
            try
            {
                var result = await _userManager.CreateAsync(client, client.PasswordHash);
                if (!result.Succeeded) return Json(new
                {
                    result = false,
                    msg = "Something happend please try again later"
                });
                await _userManager.AddToRoleAsync(client, "Client");
                return Json(new { result = true, msg = "Create new Client success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = true, msg = ex });
            }
        }

        [HttpPut]
        [ValidModel]
        public IActionResult UpdateClientInfo(Client clientDto)
        {
            var client = Mapper.Map<User>(clientDto);
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [ValidModel]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            try
            {
                var clientToDelete = await _unitOfWork.UserRepository.GetByIdAsync(id);
                await _unitOfWork.UserRepository.DeleteAsync(clientToDelete);
                return Json(new { result = true, msg = "Delete client success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, msg = ex });
            }
        }

        #endregion Manage Account
    }
}
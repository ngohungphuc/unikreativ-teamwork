using System;
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
using Unikreativ.Helper.Auth;

namespace Unikreativ.Controllers.API
{
    [Authorize("Bearer")]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private UserManager<User> _userManager;
        private readonly IUserServices _userServices;
        private readonly ValidateAccount _validateAccount;

        public AdminController(
            UserManager<User> userManager,
            IUserServices userServices,
            ValidateAccount validateAccount)
        {
            _userManager = userManager;
            _userServices = userServices;
            _validateAccount = validateAccount;
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
                if (await _validateAccount.CheckAccountExist(clientDto.UserName)) return Json(new { result = false, msg = "Account already exist" });
                if (await _validateAccount.CheckEmailExist(clientDto.Email)) return Json(new { result = false, msg = "Email already exist" });

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
        public async Task<IActionResult> UpdateClientInfo([FromBody] Client clientDto)
        {
            try
            {
                var client = await _unitOfWork.UserRepository.GetByIdAsync(clientDto.Id);
                if (client == null) return Json(new { result = false, msg = "Account not exist" });
                var clientToUpdate = Mapper.Map<User>(clientDto);
                await _unitOfWork.UserRepository.UpdateAsync(clientToUpdate, clientToUpdate.Id);
                return Json(new { result = true, msg = "Update Client success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = true, msg = ex });
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
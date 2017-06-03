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
    [Route("api/[controller]/[action]")]
    [Authorize("Bearer")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public AdminController(
            IUserServices userServices,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _userServices = userServices;
            _mapper = mapper;
        }

        #region Manage Account

        [ValidModel]
        public IActionResult UpdateClientInfo(Client clientDto)
        {
            var client = _mapper.Map<User>(clientDto);
            _unitOfWork.UserRepository.Edit(client);
            _unitOfWork.Commit();
            return Ok();
        }

        #endregion Manage Account
    }
}
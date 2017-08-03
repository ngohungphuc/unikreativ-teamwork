﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unikreativ.Entities.Entities;
using Unikreativ.Entities.ViewModel;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Confirm;
using Unikreativ.Helper.Filter;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Authorize("Bearer")]
    [Route("api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;
        private readonly ValidateAccount _validateAccount;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IEventService _eventService;
        private readonly IUserResolverService _userResolverService;
        public ProjectController(
            UserManager<User> userManager,
            IUserServices userServices,
            IAccountServices accountServices,
            ValidateAccount validateAccount,
            IEmailSender emailSender,
            IEmailTemplateService emailTemplateService,
            IEventService eventService,
            IUserResolverService userResolverService)
        {
            _userManager = userManager;
            _userServices = userServices;
            _validateAccount = validateAccount;
            _emailSender = emailSender;
            _accountServices = accountServices;
            _emailTemplateService = emailTemplateService;
            _eventService = eventService;
            _userResolverService = userResolverService;
        }


        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewProject([FromBody] ProjectViewModel projectDto)
        {
            var project = Mapper.Map<Project>(projectDto);
            project.Client = await _userResolverService.GetUser();

            await _unitOfWork.ProjectRepository.AddAsync(project);
            var eventData = await _eventService.AddEventAsync(project);

            return Json(new { result = true, msg = "New project success" });

        }

    }
}

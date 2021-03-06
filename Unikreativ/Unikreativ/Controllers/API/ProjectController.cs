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
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;
        private readonly IValidateAccount _validateAccount;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IEventService _eventService;
        private readonly IUserResolverService _userResolverService;
        private readonly IProjectServices _projectService;
        public ProjectController(
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            IUserServices userServices,
            IAccountServices accountServices,
            IValidateAccount validateAccount,
            IEmailSender emailSender,
            IEmailTemplateService emailTemplateService,
            IEventService eventService,
            IUserResolverService userResolverService,
            IProjectServices projectService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userServices = userServices;
            _validateAccount = validateAccount;
            _emailSender = emailSender;
            _accountServices = accountServices;
            _emailTemplateService = emailTemplateService;
            _eventService = eventService;
            _userResolverService = userResolverService;
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetProjectList()
        {
            var projectList = _unitOfWork.Repository<Project>()
                .Filter(includeProperties: "Client,Billings,TasksRequests,SubTasks");
            return Ok(projectList);
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectByName(string projectName)
        {
            var projectInfo = await _projectService.GetProjectByName(projectName); 
            return Ok(projectInfo);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> NewProject([FromBody] ProjectViewModel projectDto)
        {
            var project = Mapper.Map<Project>(projectDto);
            project.Client =  await _unitOfWork.Repository<User>().FindAsync(u => u.UserName == projectDto.UserName);

            await _projectService.AddProjectAsync(project);
            var eventData = await _eventService.AddEventAsync(project);

            return Json(new { result = true, msg = "Create new project success", eventData });

        }
    }
}

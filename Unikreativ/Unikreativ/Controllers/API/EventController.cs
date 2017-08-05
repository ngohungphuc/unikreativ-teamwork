using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Entities;
using Unikreativ.Helper.Auth;
using Unikreativ.Helper.Confirm;
using Unikreativ.Repositories.UnitOfWork;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Authorize("Bearer")]
    [Route("api/[controller]/[action]")]
    public class EventController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly UserManager<User> _userManager;
        private readonly IUserServices _userServices;
        private readonly IAccountServices _accountServices;
        private readonly IValidateAccount _validateAccount;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IEventService _eventService;
        public EventController(
            UserManager<User> userManager,
            IUserServices userServices,
            IAccountServices accountServices,
            IValidateAccount validateAccount,
            IEmailSender emailSender,
            IEmailTemplateService emailTemplateService,
            IEventService eventService)
        {
            _userManager = userManager;
            _userServices = userServices;
            _validateAccount = validateAccount;
            _emailSender = emailSender;
            _accountServices = accountServices;
            _emailTemplateService = emailTemplateService;
            _eventService = eventService;
        }

        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _unitOfWork.EventRepository.GetAllAsync();
            return Ok(events);
        }
    }
}

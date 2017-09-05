using System;
using Microsoft.AspNetCore.Mvc;
using Unikreativ.Entities.Models.AccountViewModels;
using Unikreativ.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Unikreativ.Helper.Auth;
using Newtonsoft.Json;
using Unikreativ.Entities.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Unikreativ.Helper.Filter;
using Unikreativ.Helper.Message;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserServices _userServices;

        public AuthController(
             UserManager<User> userManager,
             SignInManager<User> signInManager,
             IUserServices userServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServices = userServices;
        }

        //[HttpPost]
        //[ValidModel]
        //public async Task<string> GetAuthToken([FromBody] LoginViewModel userDto)
        //{
        //    var user = await _userManager.FindByNameAsync(userDto.Username);

        //    if (user == null) return AccountValidate.ValidationMessage(RequestState.Failed, "User account not exists");
        //    if (!await _userManager.IsEmailConfirmedAsync(user)) return AccountValidate.ValidationMessage(RequestState.Failed, "You must have a confirmed email to log in.");

        //    var result = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, true);
        //    if (result.IsLockedOut) return AccountValidate.ValidationMessage(RequestState.Failed, "User account locked out.");

        //    if (!result.Succeeded) return AccountValidate.ValidationMessage(RequestState.Failed, "Account credentails is not valid");
        //    var requesAt = DateTime.Now;
        //    var expiresIn = requesAt + TokenAuthOption.ExpiresSpan;

        //    //need to pass user id for generate token
        //    var token = TokenHelper.GenerateToken(user, expiresIn);

        //    return JsonConvert.SerializeObject(new RequestResult
        //    {
        //        State = RequestState.Success,
        //        Data = new
        //        {
        //            requesAt,
        //            expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
        //            tokenType = TokenAuthOption.TokenType,
        //            accessToken = token
        //        }
        //    });

        //}

        [HttpGet]
        [Authorize("Bearer")]
        public string GetUserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return JsonConvert.SerializeObject(new RequestResult
            {
                State = RequestState.Success,
                Data = new
                {
                    UserName = claimsIdentity.Name
                }
            });
        }
    }
}
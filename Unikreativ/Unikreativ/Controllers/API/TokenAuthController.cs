using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Unikreativ.Services.Interface;

namespace Unikreativ.Controllers.API
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserServices _userServices;

        public TokenAuthController(
             UserManager<User> userManager,
             SignInManager<User> signInManager,
             IUserServices userServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServices = userServices;
        }

        [HttpPost]
        [Route("GetAuthToken")]
        public string GetAuthToken([FromBody] LoginViewModel user)
        {
            var result = _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);
            if (!result.Result.Succeeded)
                return JsonConvert.SerializeObject(new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Username or password is invalid"
                });

            var requesAt = DateTime.Now;
            var expiresIn = requesAt + TokenAuthOption.ExpiresSpan;

            //need to pass user id for generate token
            var userExist = _userServices.GetUserByName(user.Username);
            var token = GenerateToken(userExist, expiresIn);

            return JsonConvert.SerializeObject(new RequestResult
            {
                State = RequestState.Success,
                Data = new
                {
                    requesAt = requesAt,
                    expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                    tokenType = TokenAuthOption.TokenType,
                    accessToken = token
                }
            });
        }

        private string GenerateToken(User user, DateTime expiresIn)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "TokenAuth"),
                new[]
                {
                     new Claim("ID", user.Id)
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expiresIn
            });

            return handler.WriteToken(securityToken);
        }

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
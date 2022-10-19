using API.Service;
using Contracts.DTO;
using Contracts.Entity;
using Contracts.Interface;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(IUserService userService, TokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<UserDTO> Register([FromBody] RegisterCommand objReq, CancellationToken cancellationToken)
        {
            var user = await _userService.Register(objReq, cancellationToken);
            var userDto = new UserDTO
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

            return userDto;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<UserDTO> Login([FromBody] LoginCommand objReq, CancellationToken cancellationToken)
        {
            var user = await _userService.Find(objReq, cancellationToken);

            if (user == null) throw new Exception();

            var result = await _signInManager.CheckPasswordSignInAsync(user, objReq.Password, false);
            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
            throw new Exception();
        }
    }
}
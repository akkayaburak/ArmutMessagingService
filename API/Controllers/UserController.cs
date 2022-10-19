using API.Service;
using Contracts.DTO;
using Contracts.Entity;
using Contracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;
        public UserController(IUserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

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
    }
}
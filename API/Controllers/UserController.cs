using Contracts.DTO;
using Contracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task Register([FromBody] RegisterCommand objReq, CancellationToken cancellationToken)
        {
            await _userService.Register(objReq, cancellationToken);
        }
    }
}
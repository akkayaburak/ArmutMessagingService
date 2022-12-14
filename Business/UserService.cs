using System.Net;
using AutoMapper;
using Contracts.Entity;
using Contracts.Interface;
using Contracts.Validators;
using Core.Exception;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Business
{
    public class UserService : BaseService, IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public UserService(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<AppUser> Register(RegisterCommand objReq, CancellationToken cancellationToken)
        {
            UserRegisterValidator validator = new UserRegisterValidator();
            var validationResult = validator.Validate(objReq);
            if (!validationResult.IsValid)
                throw new Exception("Lütfen geçerli değerler giriniz.");

            var user = _mapper.Map<AppUser>(objReq);
            var result = await _userManager.CreateAsync(user, objReq.Password);
            if (!result.Succeeded)
                throw new Exception();
            return user;
        }

        public async Task<AppUser> Find(LoginCommand objReq, CancellationToken cancellationToken)
        {
            UserLoginValidator validator = new UserLoginValidator();
            var validationResult = validator.Validate(objReq);
            if (!validationResult.IsValid)
                throw new Exception("Lütfen geçerli değerler giriniz.");

            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.UserName == objReq.UserName);

            if (user == null) throw new Exception();

            return user;
        }
    }
}
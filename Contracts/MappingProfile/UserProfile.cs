using AutoMapper;
using Contracts.Entity;
using Domain;

namespace Contracts.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterCommand, AppUser>();
        }
    }
}
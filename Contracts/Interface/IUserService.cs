using Contracts.Entity;
using Domain;

namespace Contracts.Interface
{
    public interface IUserService
    {
        public Task<AppUser> Register(RegisterCommand objReq, CancellationToken cancellationToken);
    }
}
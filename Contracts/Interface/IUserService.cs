using Contracts.DTO;

namespace Contracts.Interface
{
    public interface IUserService
    {
        public Task<bool> Register(RegisterCommand objReq, CancellationToken cancellationToken);
    }
}
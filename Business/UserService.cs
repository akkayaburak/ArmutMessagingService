using Contracts.DTO;
using Contracts.Interface;

namespace Business
{
    public class UserService : IUserService
    {
        public async Task<bool> Register(RegisterCommand objReq, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
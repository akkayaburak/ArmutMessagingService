using Contracts.DTO;
using Contracts.Entity;

namespace Contracts.Interface
{
    public interface IMessageService
    {
        public bool Insert(MessageCommand objReq);
        public MessagesDTO Get(string sender);
    }
}
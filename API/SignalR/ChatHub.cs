using Contracts.Entity;
using Contracts.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IMessageService _service;
        public ChatHub(IMessageService service)
        {
            _service = service;
        }
        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            var result = _service.Get(Context.User.Identity.Name);
            Clients.Caller.SendAsync("LoadMessages", result);
            return base.OnConnectedAsync();
        }

        public Task SendMessage(MessageCommand command)
        {
            _service.Insert(command);
            //message send to receiver only
            return Clients.Group(command.Receiver)
                .SendAsync("ReceiveMessage", command.Sender, command.Content);
        }
    }
}
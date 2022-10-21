using AutoMapper;
using Contracts.DTO;
using Contracts.Entity;
using Contracts.Interface;
using Domain;
using Persistence;

namespace Business
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MessageService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //TODO: DEFINITELY NEEDS REFACTOR
        public bool Insert(MessageCommand objReq)
        {

            var users = _context.Users.Where(x => x.UserName == objReq.Receiver || x.UserName == objReq.Sender)
                .ToList();

            if (users == null)
                throw new Exception("Lütfen kullanıcıların bilgilerini doğru giriniz.");

            var message = new Message
            {
                Sender = users.First(x => x.UserName == objReq.Sender),
                Receiver = users.First(x => x.UserName == objReq.Receiver),
                Content = objReq.Content,
                CreatedAt = DateTime.UtcNow
            };
            var result = _context.Messages.Add(message);
            return _context.SaveChanges() > 0;
        }

        //TODO: DEFINITELY NEEDS REFACTOR :(
        //TODO: Paging?
        public MessagesDTO Get(string sender)
        {
            string userId = _context.Users.SingleOrDefault(x => x.UserName == sender)?.Id;
            if (userId == null)
                return null;

            MessagesDTO messagesDTO = new MessagesDTO();

            var allMessages = _context.Messages.Where(x => x.ReceiverId == userId || x.SenderId == userId);

            messagesDTO.Sender = sender;
            messagesDTO.SenderMessages = allMessages.Where(x => x.SenderId == userId).Select(s => s.Content).ToList();

            messagesDTO.Receiver = allMessages.FirstOrDefault(x => x.SenderId == sender)?.ReceiverId;
            messagesDTO.ReceiverMessages = allMessages.Where(x => x.ReceiverId == messagesDTO.Receiver).Select(s => s.Content).ToList();

            return messagesDTO;
        }
    }
}
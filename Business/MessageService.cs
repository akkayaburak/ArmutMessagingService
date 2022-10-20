using AutoMapper;
using Contracts.Entity;
using Contracts.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Business
{
    public class MessageService : IMessageService
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
            // if (!_context.Users.Any(x => x.UserName == objReq.Receiver) || !_context.Users.Any(x => x.UserName == objReq.Sender))
            //     throw new Exception();
            var users = _context.Users.Where(x => x.UserName == objReq.Receiver || x.UserName == objReq.Sender)
                .ToList();

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
    }
}
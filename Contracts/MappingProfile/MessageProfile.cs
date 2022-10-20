using AutoMapper;
using Contracts.Entity;
using Domain;

namespace Contracts.MappingProfile
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageCommand, Message>()
                .ForMember(message => message.ReceiverId, o => o.MapFrom(messageCommand => messageCommand.Receiver))
                .ForMember(message => message.SenderId, o => o.MapFrom(messageCommand => messageCommand.Sender));
        }
    }
}
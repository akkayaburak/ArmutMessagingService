namespace Contracts.DTO
{
    public class MessagesDTO
    {
        public string Sender { get; set; }
        public List<string> SenderMessages { get; set; }
        public string Receiver { get; set; }
        public List<string> ReceiverMessages { get; set; }
    }
}
namespace Contracts.Entity
{
    public class MessageCommand
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
    }
}
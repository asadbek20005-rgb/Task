namespace Task
{
    public class MessageService
    {
        public MessageService() { 
            Messages = new List<Message>();
        }
        public List<Message> Messages { get; set; }
    }
}

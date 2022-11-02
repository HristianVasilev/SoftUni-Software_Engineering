namespace ChatApp.Models
{
    public class MessageViewModel
    {
        public MessageViewModel()
        {
        }

        public MessageViewModel(KeyValuePair<string, string> messageArgs)
        {
            Sender = messageArgs.Key;
            MessageText = messageArgs.Value;
        }

        public string? Sender { get; set; }
        public string? MessageText { get; set; }
    }
}

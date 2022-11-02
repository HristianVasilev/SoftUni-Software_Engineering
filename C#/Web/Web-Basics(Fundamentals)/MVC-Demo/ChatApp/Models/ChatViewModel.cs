namespace ChatApp.Models
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
        }

        public ChatViewModel(ICollection<MessageViewModel> messages)
        {
            Messages = messages;
        }

        public MessageViewModel? CurrentMessage { get; set; }
        public ICollection<MessageViewModel>? Messages { get; set; }
    }
}

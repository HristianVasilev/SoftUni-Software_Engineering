namespace ChatApp.Controllers
{
    using ChatApp.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        private static IList<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();


        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count() == 0)
            {
                return View(new ChatViewModel());
            }
            var messageViewModels = ConvertCollectionOfKvpToMessageViewModel(messages);
            return View(new ChatViewModel(messageViewModels));
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;
            var item = new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText);
            messages.Add(item);
            return RedirectToAction("Show");
        }

        private ICollection<MessageViewModel> ConvertCollectionOfKvpToMessageViewModel(IEnumerable<KeyValuePair<string, string>> messages)
        {
            return messages.Select(m => new MessageViewModel(m)).ToList();
        }
    }
}

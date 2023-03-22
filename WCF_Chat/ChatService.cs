using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WCF_Chat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private List<ChatUser> _users = new List<ChatUser>();
        private int _nextId = 1;

        public int Connect(string name)
        {
            ChatUser user = new ChatUser()
            {
                Id = _nextId,
                Name = name,
                OperationContext = OperationContext.Current
            };
            _nextId++;
            SendMessage($"{user.Name} has joined the chat!", 0);
            _users.Append(user);
            return user.Id;
        }

        public void Disconnect(int id)
        {
            ChatUser userToDelete = _users.FirstOrDefault(x => x.Id == id);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
            }
            SendMessage($"{userToDelete.Name} has left the chat!", 0);
        }

        public void SendMessage(string message, int id)
        {
            foreach (ChatUser user in _users)
            {

                var author = _users.FirstOrDefault(x => x.Id == id);
                string answer = $"{DateTime.Now.ToShortTimeString()}: {author?.Name} {message}";
                user.OperationContext.GetCallbackChannel<IChatCallbackService>().MessageCallback(answer);
            }
        }
    }
}

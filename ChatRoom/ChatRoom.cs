using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class ChatRoom : IChat
    {
        public string Name { get; private set; }
        public List<User> RoomUsers { get; private set; }
        public List<Message> Messages { get; private set;}
        public ChatRoom(string name)
        {
            Name = name;
            RoomUsers = new List<User>();
            Messages = new List<Message>();
        }

        public static ChatRoom CreateChatRoom(string name)
        {
            Console.WriteLine($"You created ChatRoom {name}");
            return new ChatRoom(name);
        }
        
        public void JoinChatRoom(User user)
        {
           RoomUsers.Add(user);
           Console.WriteLine($"{user.UserName} joined room ${Name}");
        }

        public void SendMessage(Message message)
        {
            Messages.Add(message);
        }

        public void DisplayMessages()
        {
            Console.Clear();
            foreach(Message message in Messages)
            {
                Console.WriteLine($"[{message.TimeStamp}] {message.Sender}: {message.Text} ");
            }
        }

       
    }
}

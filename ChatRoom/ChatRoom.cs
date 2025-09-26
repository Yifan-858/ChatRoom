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
           Console.WriteLine($"{user.UserName} joined room {Name}");
        }

        public void SendMessage(Message message)
        {
            Messages.Add(message);
            Console.WriteLine("Your message has been sent.");
        }

        public void DisplayMessages()
        {
            if (Messages.Count > 0)
            {
                foreach(Message message in Messages)
                {
                    Console.WriteLine($"[{message.TimeStamp}] {message.Sender.UserName}: {message.Text} ");
                }
            }
            else
            {
                Console.WriteLine("No one has posted anything in the room yet.");
            }
        }

        public List<(Message message,int index)>? FindUserMessages(User user)
        {
            if (Messages.Count == 0)
            {
                Console.WriteLine("No one has posted anything in the room yet.");
                Console.WriteLine("Press any key to proceed");
                Console.ReadKey();
                return null;
            }
            
            var filteredMess = Messages.Select((msg,index)=> (message:msg, index:index)).Where(x => x.message.Sender.UserName == user.UserName).ToList();

            if(filteredMess.Count == 0)
            {
                Console.WriteLine("You haven't posted anything in the room yet.");
                Console.WriteLine("Press any key to proceed");
                Console.ReadKey();
                return null;
            }

            return filteredMess;

        }

        public void EditMessage(User user)
        {
            List<(Message message,int index)>? usersMess = FindUserMessages(user);
            if(usersMess != null)
            {
                Console.WriteLine("Which message do you want to edit?");
                for (int i = 0; i < usersMess.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {usersMess[i].message.Text}");
                }
                int userChoice = int.Parse(Console.ReadLine()) - 1;
                if(userChoice >= 0 && userChoice < usersMess.Count)
                {
                    Console.WriteLine("Type in your edited message:");
                    string editedMessage = Console.ReadLine();
                    int originIndex = usersMess[userChoice].index;
                    Messages[originIndex].UpdateText(editedMessage);
                }
            }
        }
       
    }
}

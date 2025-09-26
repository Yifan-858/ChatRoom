using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public static class ChatManager
    {
        private static string[] UserAction = { "Create a chat room", "Enter an available room", "Exit" };
        private static bool inUserMenu = true;

        public static void UserMenu(List<ChatRoom> rooms,User user)
        {
            while (inUserMenu)
            {
                for(int i = 0; i < UserAction.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {UserAction[i]}");
                }
                Console.WriteLine("Your action:");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Type in a name to create a Chatroom");
                        string chatRoomName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(chatRoomName))
                        {
                            ChatRoom room1 = ChatRoom.CreateChatRoom(chatRoomName);
                            rooms.Add(room1);
                        }
                        break;

                    case 2:
                        if (rooms.Count > 0)
                        {
                            Console.WriteLine("Choose a room to enter by type in the number");
                            for(int i=0; i < rooms.Count; i++)
                            {
                                Console.WriteLine($"{i+1}. {rooms[i].Name}");  
                            } 
                            int roomChoice = int.Parse(Console.ReadLine());

                            ChatRoom selectedRoom = rooms[roomChoice - 1];
                            selectedRoom.JoinChatRoom(user);
                            
                        }
                        else
                        {
                            Console.WriteLine("No available room. Create a new one.");
                        }
                        break;
                    case 3:
                        inUserMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invaild choice");
                        break;
                       

                }
            }
        }
    }
}

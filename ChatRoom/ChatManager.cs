using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public static class ChatManager
    {
        private static string[] UserAction = { "Create a chat room", "Enter an available room", "Logout" };
        private static bool inUserMenu;

        public static void UserMenu(List<ChatRoom> rooms,User user)
        {
            inUserMenu = true;
            while (inUserMenu)
            {
                Console.Clear();
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
                            Console.WriteLine("press any key to return");
                            Console.ReadKey();
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
                            Console.WriteLine("press any key to proceed.");
                            Console.ReadKey();
                            RoomMenu(selectedRoom, user);                        
                        }
                        else
                        {
                            Console.WriteLine("No available room. Create a new one.");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("You logged out.");
                        inUserMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invaild choice");
                        break;
                       

                }
            }
        }

        private static string[] RoomActions = { "Send message", "Edit message","Detele message","Leave Room" };
        private static bool isInRoomMenu;
        public static void RoomMenu(ChatRoom room, User user)
        {
            isInRoomMenu = true;
            while (isInRoomMenu)
            {
                Console.Clear();
                room.DisplayMessages();
                for(int i = 0; i < RoomActions.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {RoomActions[i]}");
                }
                Console.WriteLine("Your action:");
                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Send your message:");
                        string messageText = Console.ReadLine();
                        Message newMessage = new Message(messageText, user);
                        room.SendMessage(newMessage);
                        Console.WriteLine("press any ket to proceed"); 
                        break;
                    case 2:
                        room.EditMessage(user);
                        break;
                    case 3:
                        room.DeleteMessage(user);
                        break;
                    case 4:
                        isInRoomMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}

            

       
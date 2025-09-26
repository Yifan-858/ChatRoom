namespace ChatRoom
{
    internal class Program
    {
       static void Main(string[] args)
        {

            List<User> allUsers = new List<User>
            {
                new User("yifan","123")
            };
            List<ChatRoom> allChatRooms = new List<ChatRoom>();
            bool inMainMenu = true;

            while (inMainMenu)
            {
                Console.WriteLine("1.Create new user.");
                Console.WriteLine("2.Login.");
                Console.WriteLine("3.Exit");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        User user = User.CreateUser();
                        allUsers.Add(user);
                        break;
                    case "2":
                        User? currentUser = User.Login(allUsers);
                        if (currentUser != null)
                        {
                            ChatManager.UserMenu(allChatRooms, currentUser);
                        }
                        break;
                    case "3":
                        inMainMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invaild choice.");
                        break;
                }
            }
           

         

            //Console.WriteLine("Send your message:");
            //string messageText = Console.ReadLine();
            //Message newMessage = new Message(messageText, user);

            //room1.SendMessage(newMessage);
            //room1.DisplayMessages();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public static User CreateUser()
        {
            string userName = "";
            string userPassword = "";

            while (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Your Name:");
                userName = Console.ReadLine();

                if(string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine("Please enter a name");
                }

            }

              while (string.IsNullOrEmpty(userPassword))
            {
                Console.WriteLine("Your Password:");
                userPassword = Console.ReadLine();

                if(string.IsNullOrEmpty(userPassword))
                {
                    Console.WriteLine("Please enter a name");
                }

            }
            
            Console.WriteLine($"Welcome, {userName}. Your account has been created!");
            Console.WriteLine("Please login first.");
            return new User(userName, userPassword);
            
        }

        public static User? Login(List<User> users)
        {
            Console.Clear();
            string inputUserName = "";
            string inputPassword = "";
            
            Console.WriteLine("== Login =="); 
            while(string.IsNullOrEmpty(inputUserName) || string.IsNullOrEmpty(inputPassword))
            {
                Console.WriteLine("User Name:");
                inputUserName = Console.ReadLine();
                Console.WriteLine("Password:");
                inputPassword = Console.ReadLine();

                if (string.IsNullOrEmpty(inputUserName) || string.IsNullOrEmpty(inputPassword))
                {
                    Console.WriteLine("User Name or Password cannot be empty.");
                }
            }

            foreach(User user in users)
            {
                if(inputUserName == user.UserName && inputPassword == user.Password)
                {
                    Console.WriteLine($"Welcome back! {user.UserName}");
                    Console.WriteLine("Press any key to proceed");
                    Console.ReadKey();
                    return user;
                }

            }

            Console.WriteLine("User name or password is not valid. Please try again.");
            return null;
           


        }
    }
}
